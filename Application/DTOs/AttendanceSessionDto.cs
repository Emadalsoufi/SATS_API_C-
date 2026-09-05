using System;

namespace Application.DTOs
{
    public class AttendanceSessionDto
    {
        public int SessionId { get; set; }
        public int CourseId { get; set; }
        public DateTime SessionDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string QRCodeToken { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }

}
