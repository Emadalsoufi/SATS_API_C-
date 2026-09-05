using Domain.Entities;
using System.Collections.Generic;
using System;

namespace Domain.Interfaces.IRepository
{
    public interface IEnrollmentRepository
    {
        void Add(Enrollment enrollment);
        void Update(Enrollment enrollment);
        void Delete(int id);
        Enrollment? GetById(int id);
        List<Enrollment> GetAll();
        List<Enrollment> GetByStudentId(int studentId);
        List<Enrollment> GetByCourseId(int courseId);
        bool Exists(int studentId, int courseId);
    }

}
