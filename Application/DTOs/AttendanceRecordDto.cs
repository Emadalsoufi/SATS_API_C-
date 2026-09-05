using System;

namespace Application.DTOs
{
    public class AttendanceRecordDto
    {
        public int RecordId { get; set; }
        public int SessionId { get; set; }
        public int StudentId { get; set; }
        public DateTime ScanTimestamp { get; set; }
        public string Status { get; set; } = string.Empty;
    }

}
