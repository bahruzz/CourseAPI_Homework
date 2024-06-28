using AutoMapper;
using Domain.Entities;
using Service.DTOs.Admin.Groups;
using Service.DTOs.Admin.Students;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Group, GroupDto>().ForMember(dest => dest.StudentCount, opt => opt.MapFrom(src => src.StudentGroups.Count));
            CreateMap<GroupCreateDto, Group>();
            CreateMap<GroupEditDto, Group>();


            CreateMap<Student, StudentDto>();/*.ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.StudentGroups));*/
            CreateMap<StudentCreateDto, Student>();
            CreateMap<StudentEditDto, Student>();
            CreateMap<StudentGroup, StudentGroupDto>().ReverseMap();
        }
    }
}
