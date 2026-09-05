using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public string CourseCode { get; set; } = string.Empty;
        public int InstructorId { get; set; }
        public User Instructor { get; set; } = null!;
        public List<Enrollment> Enrollments { get; set; } = new();
        public List<AttendanceSession> AttendanceSessions { get; set; } = new();
    }

}
