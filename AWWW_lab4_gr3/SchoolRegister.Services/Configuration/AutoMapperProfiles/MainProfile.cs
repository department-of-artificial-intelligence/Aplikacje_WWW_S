// Plik: SchoolRegister.Services/Configuration/AutoMapperProfiles/MainProfile.cs
using AutoMapper;
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM; // <<< ZMIANA TUTAJ: używamy podfolderu VM
using System.Linq;

namespace SchoolRegister.Services.Configuration.AutoMapperProfiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            // Mapowanie z encji Subject na SubjectVm
            CreateMap<Subject, SubjectVm>()
                .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src =>
                    src.Teacher != null ? $"{src.Teacher.FirstName} {src.Teacher.LastName}" : "N/A"))
                .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId))
                .ForMember(dest => dest.Groups, opt => opt.MapFrom(src =>
                    src.SubjectGroups.Select(sg => sg.Group)));

            // Mapowanie z AddOrUpdateSubjectVm na encję Subject
            CreateMap<AddOrUpdateSubjectVm, Subject>();
            
            CreateMap<Teacher, TeacherVm>(); 
            CreateMap<AddOrUpdateTeacherVm, Teacher>();

            CreateMap<Group, GroupVm>()
                .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students))
                .ForMember(dest => dest.Subjects, opt => opt.MapFrom(src =>
                    src.SubjectGroups.Select(sg => sg.Subject)));
            CreateMap<AddOrUpdateGroupVm, Group>();

                        // Mapowania dla Oceny (Grade)
            CreateMap<Grade, GradeVm>()
                .ForMember(dest => dest.GradeValue, opt => opt.MapFrom(src => src.GradeValue)) // Zakładając, że Grade ma GradeValue typu GradeScale
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject != null ? src.Subject.Name : string.Empty))
                .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student != null ? $"{src.Student.FirstName} {src.Student.LastName}" : string.Empty))
                .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.IssuedByTeacher != null ? $"{src.IssuedByTeacher.FirstName} {src.IssuedByTeacher.LastName}" : string.Empty));
                // DateOfIssue powinno mapować się automatycznie

            // Mapowanie z AddGradeToStudentVm na encję Grade
            
            CreateMap<AddGradeToStudentVm, Grade>()
                .ForMember(dest => dest.DateOfIssue, opt => opt.MapFrom(src => DateTime.UtcNow));  
            

            // Mapowanie z encji Student na StudentVm
            CreateMap<Student, StudentVm>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.ParentName, opt => opt.MapFrom(src =>
                    src.Parent != null ? $"{src.Parent.FirstName} {src.Parent.LastName}" : "N/A")) // Zakładając, że Student ma nawigację do Parent, a Parent ma FirstName, LastName
                .ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => src.ParentId))
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(src =>
                    src.Group != null ? src.Group.Name : "N/A")) // Zakładając, że Student ma nawigację do Group
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName)) // UserName jest w klasie bazowej User
                // Mapowania dla AverageGrade, AverageGradePerSubject, GradesPerSubject będą wymagały bardziej złożonej logiki,
                // prawdopodobnie obliczanej w serwisie, a nie bezpośrednio przez AutoMapper z encji.
                // Na razie możemy je pominąć w mapowaniu lub ustawić, aby były ignorowane, jeśli nie mają bezpośredniego odpowiednika w encji Student.
                .ForMember(dest => dest.AverageGrade, opt => opt.Ignore()) // Lub opt.MapFrom(src => /* jakaś logika, jeśli jest w encji */))
                .ForMember(dest => dest.AverageGradePerSubject, opt => opt.Ignore())
                .ForMember(dest => dest.GradesPerSubject, opt => opt.Ignore());

            // Mapowanie dla encji Parent (dziedziczącej po User) na (ewentualny) ParentVm
            // CreateMap<Parent, ParentVm>()
            //     .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            // ... inne mapowania
        }
    }
}