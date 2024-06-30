using AutoMapper;
using Domain.Entities;
using Service.DTOs.Admin.Educations;
using Service.DTOs.Admin.Groups;
using Service.DTOs.Admin.Rooms;
using Service.DTOs.Admin.Students;
using Service.DTOs.Admin.Teachers;
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
            CreateMap<Group, GroupDto>().ForMember(dest => dest.StudentCount, opt => opt.MapFrom(src => src.StudentGroups.Count))       
                .ForMember(dest => dest.RoomName, opt => opt.MapFrom(src => src.Room.Name))
                .ForMember(dest => dest.EducationName, opt => opt.MapFrom(src => src.Education.Name));
            CreateMap<GroupCreateDto, Group>();
            CreateMap<GroupEditDto, Group>();
            CreateMap<GroupTeacher, GroupTeacherDto>().ReverseMap();



            CreateMap<Student, StudentDto>();/*.ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.StudentGroups));*/
            CreateMap<StudentCreateDto, Student>();
            CreateMap<StudentEditDto, Student>().ForMember(dest => dest.StudentGroups, opt => opt.MapFrom(src => src.GroupId));
            CreateMap<StudentGroup, StudentGroupDto>().ReverseMap();



            CreateMap<Teacher, TeacherDto>().ForMember(dest => dest.Groups, opt => opt.MapFrom(src =>
               src.GroupTeachers.Select(gs => gs.Group))); ;
            CreateMap<TeacherCreateDto, Teacher>().ForMember(dest => dest.GroupTeachers, opt => opt.MapFrom(src =>
        src.GroupId.Select(id => new GroupTeacher { GroupId = id }))); ;
            CreateMap<TeacherEditDto, Teacher>().ForMember(dest => dest.GroupTeachers, opt => opt.MapFrom(src =>
        src.GroupId.Select(id => new GroupTeacher { GroupId = id }))); ;


            CreateMap<Room, RoomDto>();
            CreateMap<RoomCreateDto, Room>();
            CreateMap<RoomEditDto, Room>();



            CreateMap<Education, EducationDto>();
            CreateMap<EducationCreateDto, Education>();
            CreateMap<EducationEditDto, Education>();
        }
    }
}
