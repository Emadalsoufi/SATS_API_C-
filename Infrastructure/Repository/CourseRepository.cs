using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Course course) { _context.Courses.Add(course); _context.SaveChanges(); }
        public void Update(Course course) { _context.Courses.Update(course); _context.SaveChanges(); }
        public void Delete(int id)
        {
            var item = _context.Courses.Find(id);
            if (item is not null)
            {
                _context.Courses.Remove(item);
                _context.SaveChanges();
            }
        }
        public Course? GetById(int id) => _context.Courses.Find(id);
        public List<Course> GetAll() => _context.Courses.AsNoTracking().ToList();
        public Course? GetByCode(string courseCode) => _context.Courses.AsNoTracking().FirstOrDefault(c => c.CourseCode == courseCode);
    }
}
