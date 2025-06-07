// Plik: SchoolRegister.Services/ConcreteServices/TeacherService.cs
using AutoMapper;
using Microsoft.AspNetCore.Identity; // Dla UserManager
using Microsoft.EntityFrameworkCore; // Dla Include, ThenInclude
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SchoolRegister.Services.ConcreteServices
{
    public class TeacherService : BaseService, ITeacherService
    {
        private readonly UserManager<User> _userManager; // UserManager do operacji na użytkownikach

        public TeacherService(ApplicationDbContext dbContext, IMapper mapper, ILogger<TeacherService> logger, UserManager<User> userManager)
            : base(dbContext, mapper, logger)
        {
            _userManager = userManager;
        }

        public TeacherVm GetTeacher(Expression<Func<Teacher, bool>> filterPredicate)
        {
            try
            {
                if (filterPredicate == null)
                    throw new ArgumentNullException(nameof(filterPredicate), "Filter predicate cannot be null.");

                // OfType<Teacher>() jest kluczowe, aby pracować tylko na użytkownikach, którzy są nauczycielami
                var teacherEntity = DbContext.Users.OfType<Teacher>().FirstOrDefault(filterPredicate);
                return Mapper.Map<TeacherVm>(teacherEntity);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error in GetTeacher: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<TeacherVm> GetTeachers(Expression<Func<Teacher, bool>>? filterPredicate = null)
        {
            try
            {
                var query = DbContext.Users.OfType<Teacher>().AsQueryable();
                if (filterPredicate != null)
                {
                    query = query.Where(filterPredicate);
                }
                var teacherEntities = query.ToList();
                return Mapper.Map<IEnumerable<TeacherVm>>(teacherEntities);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error in GetTeachers: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<GroupVm> GetTeachersGroups(Expression<Func<Teacher, bool>> filterPredicate)
        {
            try
            {
                if (filterPredicate == null)
                    throw new ArgumentNullException(nameof(filterPredicate), "Filter predicate cannot be null for GetTeachersGroups.");

                // Znajdź nauczyciela
                var teacher = DbContext.Users.OfType<Teacher>()
                                    .Include(t => t.Subjects)  
                                        .ThenInclude(s => s.SubjectGroups) // Załaduj powiązania przedmiot-grupa
                                            .ThenInclude(sg => sg.Group) // Załaduj same grupy
                                    .FirstOrDefault(filterPredicate);

                if (teacher == null || teacher.Subjects == null)
                {
                    return Enumerable.Empty<GroupVm>();
                }

                 
                var groups = teacher.Subjects
                                    .SelectMany(s => s.SubjectGroups)
                                    .Select(sg => sg.Group)
                                    .Where(g => g != null) // Upewnij się, że grupa nie jest null
                                    .Distinct() // Tylko unikalne grupy
                                    .ToList();

                return Mapper.Map<IEnumerable<GroupVm>>(groups);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error in GetTeachersGroups: {ex.Message}");
                throw;
            }
        }
    }
}