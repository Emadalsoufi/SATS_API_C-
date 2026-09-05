using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(User user) { _context.Users.Add(user); _context.SaveChanges(); }
        public void Update(User user) { _context.Users.Update(user); _context.SaveChanges(); }
        public void Delete(int id)
        {
            var item = _context.Users.Find(id);
            if (item is not null)
            {
                _context.Users.Remove(item);
                _context.SaveChanges();
            }
        }
        public User? GetById(int id) => _context.Users.Find(id);
        public List<User> GetAll() => _context.Users.AsNoTracking().ToList();
        public User? GetByEmail(string email) => _context.Users.AsNoTracking().FirstOrDefault(u => u.Email == email);
    }
}
