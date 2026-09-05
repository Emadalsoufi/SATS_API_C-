using System;

namespace Application.DTOs
{
    public class AuditLogDto
    {
        public int AuditLogId { get; set; }
        public int UserId { get; set; }
        public string Action { get; set; } = string.Empty;
        public int? AttendanceRecordId { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
