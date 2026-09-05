using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public List<Course> CoursesTaught { get; set; } = new();
        public List<Enrollment> Enrollments { get; set; } = new();
        public List<AttendanceRecord> AttendanceRecords { get; set; } = new();
        public List<AuditLog> AuditLogs { get; set; } = new();
    }
}
