using Application.DTOs;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface ICourseService
    {
        void CreateCourse(CourseDto courseDto);
        void UpdateCourse(CourseDto courseDto);
        CourseDto? GetCourseById(int id);
        IEnumerable<CourseDto> GetAllCourses();
    }

}
