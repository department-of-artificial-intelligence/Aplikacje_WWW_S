using AutoMapper; 
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM; 

namespace SchoolRegister.Services.Configuration.AutoMapperProfiles; 

public class MainProfile: Profile {

    public MainProfile() {

        // Mapy AutoMappera
        CreateMap<Subject, SubjectVm>()
            .ForMember(dest => dest.TeacherName, x => x.MapFrom(src => src.Teacher == null ? null : $"{src.Teacher.FirstName} {src.Teacher.LastName}")); 

        
        CreateMap<AddOrUpdateSubjectVm, Subject>(); 

        CreateMap<Group, GroupVm>()
            .ForMember(dest => dest.Students, x => x.MapFrom(src => src.Students))
            .ForMember(dest => dest.Subjects, x=>x.MapFrom(src => src.SubjectGroups.Select(sg => sg.Subject))); 

        CreateMap<SubjectVm, AddOrUpdateSubjectVm>(); 

        CreateMap<Student, StudentVm>()
            .ForMember(dest => dest.GroupName, x => x.MapFrom(src => src.Group == null ? null : src.Group.Name))
            .ForMember(dest => dest.ParentName, x => x.MapFrom(src => src.Parent == null ? null : $"{src.Parent.FirstName} {src.Parent.LastName}")); 




        CreateMap<Teacher, TeacherVm>()
            .ForMember(dest => dest.Subjects, x => x.MapFrom(src => src.Subjects.Select(s => new SubjectVm {
                Id = s.Id, 
                Description = s.Description, 
                Groups = s.SubjectGroups.Select(sg => new GroupVm {
                    Id = sg.Group.Id, 
                    Name = sg.Group.Name
                }).ToList()
            })));

        CreateMap<Teacher, TeachersGroupsVm>()
            .ForMember(dest => dest.TeacherId, x => x.MapFrom(src => src.Id))
            .ForMember(dest => dest.TeacherName, x => x.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.Groups, x => x.MapFrom(src => src.Subjects.Select(s => s.SubjectGroups.Select(sg => new GroupVm {
                Id = sg.Group.Id, 
                Name = sg.Group.Name
            })))); 
            

        // zobaczyc czy dziala
        CreateMap<Grade, GradeVm>()
            .ForMember(dest => dest.SubjectName, x => x.MapFrom(src => $"{src.Subject.Name}"))
            .ForMember(dest => dest.StudentName, x => x.MapFrom(src => $"{src.Student.FirstName} {src.Student.LastName}")); 

        // wersja jawna - pelna: 
        // .ForMember(dest => dest.Subject, x => x.MapFrom(src => new SubjectVm {
        //         Id = src.Subject.Id, 
        //         Description = src.Subject.Description, 
        //         Groups = src.Subject.SubjectGroups.Select(sg => new GroupVm {
        //             Id = sg.Group.Id, 
        //             Name = sg.Group.Name
        //         }).ToList() 
        //     })) 

        CreateMap<Student, GradesReportVm>()
            .ForMember(dest => dest.StudentName, x => x.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.Grades, x => x.MapFrom(src => src.Grades.Select(g => new GradeVm {
                DateOfIssue = g.DateOfIssue, 
                GradeValue = g.GradeValue, 
                StudentId = g.StudentId, 
                StudentName = $"{src.FirstName} {src.LastName}", 
                SubjectId = g.SubjectId, 
                SubjectName = $"{g.Subject.Name}"
            })));  


        CreateMap<RegisterNewUserVm, User>()
            .ForMember(dest => dest.UserName, y => y.MapFrom(src => src.Email))
            .ForMember(dest => dest.RegistrationDate, y => y.MapFrom(src => DateTime.Now));
        CreateMap<RegisterNewUserVm, Parent>()
            .ForMember(dest => dest.UserName, y => y.MapFrom(src => src.Email))
            .ForMember(dest => dest.RegistrationDate, y => y.MapFrom(src => DateTime.Now));
        CreateMap<RegisterNewUserVm, Student>()
            .ForMember(dest => dest.UserName, y => y.MapFrom(src => src.Email))
            .ForMember(dest => dest.RegistrationDate, y => y.MapFrom(src => DateTime.Now));
        CreateMap<RegisterNewUserVm, Teacher>()
            .ForMember(dest => dest.UserName, y => y.MapFrom(src => src.Email))
            .ForMember(dest => dest.RegistrationDate, y => y.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.Title, y => y.MapFrom(src => src.TeacherTitles));

    }

}