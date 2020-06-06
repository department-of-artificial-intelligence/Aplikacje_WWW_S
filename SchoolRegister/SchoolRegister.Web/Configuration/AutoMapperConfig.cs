using AutoMapper;
using SchoolRegister.BLL.Entities;
using SchoolRegister.ViewModels.DTOs;
using SchoolRegister.ViewModels.VMs;
using System;
using System.Linq;

namespace SchoolRegister.Web.Configuration
{
    public static class AutoMapperConfig
    {
        public static IMapperConfigurationExpression Mapping(this IMapperConfigurationExpression configurationExpression)
        {
            Mapper.Initialize(mapper =>
            {
                mapper.CreateMap<AddOrUpdateSubjectDto, Subject>();
                mapper.CreateMap<Group, GroupVm>();
                mapper.CreateMap<Subject, SubjectVm>()
                    .ForMember(dest => dest.TeacherName, x => x.MapFrom(src => $"{src.Teacher.FirstName} {src.Teacher.LastName}"))
                    .ForMember(dest => dest.Groups, x => x.MapFrom(src => src.SubjectGroups.Select(y => y.Group)));
                mapper.CreateMap<SubjectVm, AddOrUpdateSubjectDto>();
                mapper.CreateMap<Teacher, TeacherVm>();
                mapper.CreateMap<AddOrUpdateGroupDto, Group>();
                mapper.CreateMap<Student, StudentVm>()
                    .ForMember(dest => dest.GroupName, x => x.MapFrom(src => src.Group.Name))
                    .ForMember(dest => dest.ParentName,
                        x => x.MapFrom(src => $"{src.Parent.FirstName} {src.Parent.LastName}"));
                mapper.CreateMap<AddGradeToStudentDto, Grade>()
                    .ForMember(dest => dest.DateOfIssue, y => y.MapFrom(src => DateTime.Now));
                mapper.CreateMap<GroupVm, AddOrUpdateGroupDto>();
                mapper.CreateMap<Student, GradesReportVm>()
                    .ForMember(dest => dest.StudentLastName, y => y.MapFrom(src => src.LastName))
                    .ForMember(dest => dest.StudentFirstName, y => y.MapFrom(src => src.FirstName))
                    .ForMember(dest => dest.GroupName, y => y.MapFrom(src => src.Group.Name))
                    .ForMember(dest => dest.ParentName, y => y.MapFrom(src => $"{src.Parent.FirstName} {src.Parent.LastName}"))
                    .ForMember(dest => dest.StudentGradesPerSubject, y => y.MapFrom(src => src.Grades
                        .GroupBy(g => g.Subject.Name)
                        .Select(g => new { SubjectName = g.Key, Grades = g.Select(gl => gl.GradeValue).ToList() })
                        .ToDictionary(x => x.SubjectName, x => x.Grades)));
            });
            return configurationExpression;
        }
    }
}
