using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Domain.Entities
{
    public class AttendanceRecord
    {
        [Key]
        public int RecordId { get; set; }
        public int SessionId { get; set; }
        public AttendanceSession Session { get; set; } = null!;
        public int StudentId { get; set; }
        public User Student { get; set; } = null!;
        public DateTime ScanTimestamp { get; set; }
        public string Status { get; set; } = string.Empty;
        public List<AuditLog> AuditLogs { get; set; } = new();
    }

}
