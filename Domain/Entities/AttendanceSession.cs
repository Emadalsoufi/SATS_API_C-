using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class AttendanceSession
    {
        public int SessionId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public DateTime SessionDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string QRCodeToken { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public List<AttendanceRecord> AttendanceRecords { get; set; } = new();
    }

}
