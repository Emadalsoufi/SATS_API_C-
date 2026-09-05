using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Enrollment, EnrollmentDto>().ReverseMap();
            CreateMap<AttendanceSession, AttendanceSessionDto>().ReverseMap();
            CreateMap<AttendanceRecord, AttendanceRecordDto>().ReverseMap();
            CreateMap<AuditLog, AuditLogDto>().ReverseMap();
        }
    }

}
