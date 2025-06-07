// Plik: SchoolRegister.Services/ConcreteServices/GradeService.cs
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; // Potrzebne dla metod asynchronicznych UserManagera

namespace SchoolRegister.Services.ConcreteServices
{
    public class GradeService : BaseService, IGradeService
    {
        private readonly UserManager<User> _userManager;

        public GradeService(ApplicationDbContext dbContext, IMapper mapper, ILogger<GradeService> logger, UserManager<User> userManager)
            : base(dbContext, mapper, logger)
        {
            _userManager = userManager;
        }

        public GradeVm AddGradeToStudent(AddGradeToStudentVm addGradeToStudentVm)
        {
            try
            {
                if (addGradeToStudentVm == null)
                {
                    Logger.LogError("AddGradeToStudentVm is null.");
                    throw new ArgumentNullException(nameof(addGradeToStudentVm), "Grade data cannot be null.");
                }

                // Walidacja istnienia studenta
                var student = DbContext.Users.OfType<Student>()
                                       .Include(s => s.Grades) // Aby móc np. sprawdzić liczbę ocen z przedmiotu
                                       .FirstOrDefault(s => s.Id == addGradeToStudentVm.StudentId);
                if (student == null)
                {
                    Logger.LogWarning($"Student with Id {addGradeToStudentVm.StudentId} not found.");
                    throw new InvalidOperationException($"Student with Id {addGradeToStudentVm.StudentId} not found.");
                }

                // Walidacja istnienia przedmiotu
                var subject = DbContext.Subjects.Find(addGradeToStudentVm.SubjectId);
                if (subject == null)
                {
                    Logger.LogWarning($"Subject with Id {addGradeToStudentVm.SubjectId} not found.");
                    throw new InvalidOperationException($"Subject with Id {addGradeToStudentVm.SubjectId} not found.");
                }

                // Walidacja istnienia nauczyciela wystawiającego ocenę
                var issuingTeacher = DbContext.Users.OfType<Teacher>().FirstOrDefault(t => t.Id == addGradeToStudentVm.IssuedByTeacherId);
                if (issuingTeacher == null)
                {
                    Logger.LogWarning($"Teacher (issuer) with Id {addGradeToStudentVm.IssuedByTeacherId} not found or is not a Teacher.");
                    throw new InvalidOperationException($"Teacher (issuer) with Id {addGradeToStudentVm.IssuedByTeacherId} not found or is not a Teacher.");
                }

                // Dodatkowa logika biznesowa (zgodnie z sugestiami z instrukcji):
                // 1. Sprawdź, czy nauczyciel wystawiający ocenę (issuingTeacher) uczy danego przedmiotu (subject).
                if (subject.TeacherId != issuingTeacher.Id)
                {
                    Logger.LogWarning($"Teacher {issuingTeacher.UserName} (Id: {issuingTeacher.Id}) is not assigned to subject {subject.Name} (Id: {subject.Id}). Subject taught by TeacherId: {subject.TeacherId}.");
                    throw new InvalidOperationException($"Teacher {issuingTeacher.FirstName} {issuingTeacher.LastName} does not teach the subject '{subject.Name}'.");
                }

                // 2. Sprawdź, czy student (student) jest zapisany na dany przedmiot (subject) - poprzez SubjectGroups.
                // Zakładamy, że Student ma GroupId i Group, a Subject ma SubjectGroups.
                var studentGroup = DbContext.Groups.Include(g => g.SubjectGroups)
                                            .FirstOrDefault(g => g.Id == student.GroupId);
                
                if (studentGroup == null || !studentGroup.SubjectGroups.Any(sg => sg.SubjectId == subject.Id))
                {
                    Logger.LogWarning($"Student {student.UserName} (Group: {studentGroup?.Name}) is not enrolled in subject {subject.Name}.");
                    throw new InvalidOperationException($"Student {student.FirstName} {student.LastName} is not enrolled in the subject '{subject.Name}'.");
                }


                // Tworzenie nowej encji Grade
                var gradeEntity = Mapper.Map<Grade>(addGradeToStudentVm);
                // Data wystawienia jest już ustawiana przez AutoMapper z AddGradeToStudentVm,
                // lub można ją ustawić tutaj, jeśli logika jest inna.
                // gradeEntity.DateOfIssue = DateTime.UtcNow; // Jeśli AutoMapper tego nie robił

                DbContext.Grades.Add(gradeEntity);
                DbContext.SaveChanges();

                // Pobierz świeżo dodaną ocenę z załadowanymi danymi do mapowania na GradeVm
                var createdGrade = DbContext.Grades
                                        .Include(g => g.Subject)
                                        .Include(g => g.Student)
                                        .Include(g => g.IssuedByTeacher)
                                        .FirstOrDefault(g => g.Id == gradeEntity.Id);

                return Mapper.Map<GradeVm>(createdGrade);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error in AddGradeToStudent: {ex.Message}");
                throw;
            }
        }

        public GradesReportVm GetGradesReportForStudent(GetGradesReportVm getGradesReportVm)
        {
            try
            {
                if (getGradesReportVm == null)
                {
                    Logger.LogError("GetGradesReportVm is null.");
                    throw new ArgumentNullException(nameof(getGradesReportVm), "Report request data cannot be null.");
                }

                var student = DbContext.Users.OfType<Student>()
                                       .Include(s => s.Group) // Potrzebne dla GroupName
                                       .Include(s => s.Grades)
                                           .ThenInclude(g => g.Subject) // Dla SubjectName i SubjectAverageGrade
                                               .ThenInclude(sub => sub.Teacher) // Dla TeacherFullName w SubjectGradesVm
                                       .FirstOrDefault(s => s.Id == getGradesReportVm.StudentId);

                if (student == null)
                {
                    Logger.LogWarning($"Student with Id {getGradesReportVm.StudentId} not found for grades report.");
                    throw new InvalidOperationException($"Student with Id {getGradesReportVm.StudentId} not found.");
                }

                var report = new GradesReportVm
                {
                    StudentFullName = $"{student.FirstName} {student.LastName}",
                    GroupName = student.Group?.Name ?? "N/A" // Grupa może być null
                };

                var gradesBySubject = student.Grades
                                            .Where(g => g.Subject != null) // Upewnij się, że ocena ma przedmiot
                                            .GroupBy(g => g.Subject);

                double totalAverageSum = 0;
                int subjectsWithGradesCount = 0;

                foreach (var group in gradesBySubject)
                {
                    var subject = group.Key;
                    var subjectGrades = group.ToList();

                    var subjectGradesVm = new SubjectGradesVm
                    {
                        SubjectName = subject.Name,
                        TeacherFullName = subject.Teacher != null ? $"{subject.Teacher.FirstName} {subject.Teacher.LastName}" : "N/A",
                        Grades = Mapper.Map<List<GradeVm>>(subjectGrades) // Mapujemy listę ocen dla przedmiotu
                    };

                    if (subjectGrades.Any())
                    {
                        // Proste obliczenie średniej, zakładając, że GradeScale można rzutować na double
                        // W rzeczywistości logika obliczania średniej może być bardziej złożona (wagi ocen itp.)
                        subjectGradesVm.SubjectAverageGrade = subjectGrades.Average(g => (double)(int)g.GradeValue); // Przykładowe rzutowanie
                        totalAverageSum += subjectGradesVm.SubjectAverageGrade;
                        subjectsWithGradesCount++;
                    }
                    else
                    {
                        subjectGradesVm.SubjectAverageGrade = 0;
                    }
                    report.SubjectsGrades.Add(subjectGradesVm);
                }

                if (subjectsWithGradesCount > 0)
                {
                    report.FinalAverageGrade = totalAverageSum / subjectsWithGradesCount;
                }
                else
                {
                    report.FinalAverageGrade = 0;
                }

                return report;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error in GetGradesReportForStudent: {ex.Message}");
                throw;
            }
        }
    }
}