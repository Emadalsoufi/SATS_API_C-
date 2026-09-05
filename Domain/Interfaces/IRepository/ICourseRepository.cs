using Domain.Entities;
using System.Collections.Generic;
using System;

namespace Domain.Interfaces.IRepository
{
    public interface ICourseRepository
    {
        void Add(Course course);
        void Update(Course course);
        void Delete(int id);
        Course? GetById(int id);
        List<Course> GetAll();
        Course? GetByCode(string courseCode);
    }
}
