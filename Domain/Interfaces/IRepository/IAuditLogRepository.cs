using Domain.Entities;
using System.Collections.Generic;
using System;

namespace Domain.Interfaces.IRepository
{
    public interface IAuditLogRepository
    {
        void Add(AuditLog log);
        void Update(AuditLog log);
        AuditLog? GetById(int id);
        List<AuditLog> GetAll();
        List<AuditLog> GetByUserId(int userId);
        List<AuditLog> GetByAttendanceRecordId(int attendanceRecordId);
    }
}
