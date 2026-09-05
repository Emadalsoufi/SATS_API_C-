using Domain.Entities;
using System;

namespace Domain.Entities
{
    public class AuditLog
    {
        public int AuditLogId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public string Action { get; set; } = string.Empty;
        public int? AttendanceRecordId { get; set; }
        public AttendanceRecord? AttendanceRecord { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
