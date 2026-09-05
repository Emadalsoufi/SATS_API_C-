using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class AttendanceRecordRepository : IAttendanceRecordRepository
    {
        private readonly AppDbContext _context;

        public AttendanceRecordRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(AttendanceRecord record) { _context.AttendanceRecords.Add(record); _context.SaveChanges(); }
        public void Update(AttendanceRecord record) { _context.AttendanceRecords.Update(record); _context.SaveChanges(); }
        public void Delete(int id)
        {
            var item = _context.AttendanceRecords.Find(id);
            if (item is not null)
            {
                _context.AttendanceRecords.Remove(item);
                _context.SaveChanges();
            }
        }
        public AttendanceRecord? GetById(int id) => _context.AttendanceRecords.Find(id);
        public List<AttendanceRecord> GetAll() => _context.AttendanceRecords.AsNoTracking().ToList();
        public AttendanceRecord? GetByStudentAndSession(int studentId, int sessionId) =>
            _context.AttendanceRecords.AsNoTracking().FirstOrDefault(a => a.StudentId == studentId && a.SessionId == sessionId);
        public List<AttendanceRecord> GetBySessionId(int sessionId) =>
            _context.AttendanceRecords.AsNoTracking().Where(a => a.SessionId == sessionId).ToList();
        public bool Exists(int studentId, int sessionId) =>
            _context.AttendanceRecords.Any(a => a.StudentId == studentId && a.SessionId == sessionId);
    }
}
