using Domain.Entities;
using System.Collections.Generic;
using System;

namespace Domain.Interfaces.IRepository
{
    public interface IUserRepository
    {
        void Add(User user);
        void Update(User user);
        void Delete(int id);
        User? GetById(int id);
        List<User> GetAll();
        User? GetByEmail(string email);
    }

}
