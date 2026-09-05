using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class AuditLogRepository : IAuditLogRepository
    {
        private readonly AppDbContext _context;

        public AuditLogRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(AuditLog log) { _context.AuditLogs.Add(log); _context.SaveChanges(); }
        public void Update(AuditLog log) { _context.AuditLogs.Update(log); _context.SaveChanges(); }
        public AuditLog? GetById(int id) => _context.AuditLogs.Find(id);
        public List<AuditLog> GetAll() => _context.AuditLogs.AsNoTracking().ToList();
        public List<AuditLog> GetByUserId(int userId) =>
            _context.AuditLogs.AsNoTracking().Where(a => a.UserId == userId).ToList();
        public List<AuditLog> GetByAttendanceRecordId(int attendanceRecordId) =>
            _context.AuditLogs.AsNoTracking().Where(a => a.AttendanceRecordId == attendanceRecordId).ToList();
    }
}
