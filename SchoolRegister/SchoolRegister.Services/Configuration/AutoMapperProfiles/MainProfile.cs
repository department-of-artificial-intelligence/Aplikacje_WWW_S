using AutoMapper;
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.Configuration.AutoMapperProfiles;

public class MainProfile : Profile
{
    public MainProfile()
    {
        CreateMap<Subject, SubjectVm>()
            .ForMember(dest => dest.TeacherName, x => x.MapFrom(src => src.Teacher == null ? null : $"{src.Teacher.FirstName} {src.Teacher.LastName}"))
            .ForMember(dest => dest.Groups, x => x.MapFrom(src => src.SubjectGroups == null ? null : src.SubjectGroups.Select(s => s.Group)));

        CreateMap<AddOrUpdateSubjectVm, Subject>();

        CreateMap<Group, GroupVm>()
            .ForMember(dest => dest.Students, x => x.MapFrom(src => src.Students))
            .ForMember(dest => dest.Subjects, x => x.MapFrom(src => src.SubjectGroups == null ? null : src.SubjectGroups.Select(s => s.Subject)));

        CreateMap<Student, StudentVm>()
            .ForMember(dest => dest.ParentName, x => x.MapFrom(src => src.Parent == null ? null : $"{src.Parent.FirstName} {src.Parent.LastName}"))
            .ForMember(dest => dest.GroupName, x => x.MapFrom(src => src.Group == null ? null : src.Group.Name));

        CreateMap<SubjectVm, AddOrUpdateSubjectVm>();

        CreateMap<Teacher, TeacherVm>()
            .ForMember(dest => dest.Subjects, x => x.MapFrom(src => src.Subjects == null ? null : src.Subjects));

        CreateMap<Teacher, TeachersGroupsVm>()
            .ForMember(dest => dest.TeacherId, x => x.MapFrom(src => src.Id));

        CreateMap<Grade, GradeVm>()
            .ForMember(dest => dest.SubjectName, x => x.MapFrom(src => src.Subject.Name))
            .ForMember(dest => dest.StudentName, x => x.MapFrom(src => $"{src.Student.FirstName} {src.Student.LastName}"))
            .ForMember(dest => dest.TeacherId, x => x.MapFrom(src => src.Subject.TeacherId));

        CreateMap<GradeVm, AddGradeToStudentVm>();
        CreateMap<AddGradeToStudentVm, Grade>();
    }
}