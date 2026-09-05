using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class AttendanceSessionRepository : IAttendanceSessionRepository
    {
        private readonly AppDbContext _context;

        public AttendanceSessionRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(AttendanceSession session) { _context.AttendanceSessions.Add(session); _context.SaveChanges(); }
        public void Update(AttendanceSession session) { _context.AttendanceSessions.Update(session); _context.SaveChanges(); }
        public void Delete(int id)
        {
            var item = _context.AttendanceSessions.Find(id);
            if (item is not null)
            {
                _context.AttendanceSessions.Remove(item);
                _context.SaveChanges();
            }
        }
        public AttendanceSession? GetById(int id) => _context.AttendanceSessions.Find(id);
        public List<AttendanceSession> GetAll() => _context.AttendanceSessions.AsNoTracking().ToList();
        public AttendanceSession? GetByQRCodeToken(string token) =>
            _context.AttendanceSessions.AsNoTracking().FirstOrDefault(s => s.QRCodeToken == token);
        public List<AttendanceSession> GetByCourseId(int courseId) =>
            _context.AttendanceSessions.AsNoTracking().Where(s => s.CourseId == courseId).ToList();
    }
}
