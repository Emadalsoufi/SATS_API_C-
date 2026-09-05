using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly AppDbContext _context;

        public EnrollmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Enrollment enrollment) { _context.Enrollments.Add(enrollment); _context.SaveChanges(); }
        public void Update(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var item = _context.Enrollments.Find(id);
            if (item is not null)
            {
                _context.Enrollments.Remove(item);
                _context.SaveChanges();
            }
        }
        public Enrollment? GetById(int id) => _context.Enrollments.Find(id);
        public List<Enrollment> GetAll() => _context.Enrollments.AsNoTracking().ToList();
        public List<Enrollment> GetByStudentId(int studentId) => _context.Enrollments.AsNoTracking().Where(e => e.StudentId == studentId).ToList();
        public List<Enrollment> GetByCourseId(int courseId) => _context.Enrollments.AsNoTracking().Where(e => e.CourseId == courseId).ToList();
        public bool Exists(int studentId, int courseId) => _context.Enrollments.Any(e => e.StudentId == studentId && e.CourseId == courseId);
    }
}
