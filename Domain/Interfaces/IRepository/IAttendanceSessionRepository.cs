using Domain.Entities;
using System.Collections.Generic;
using System;

namespace Domain.Interfaces.IRepository
{
    public interface IAttendanceSessionRepository
    {
        void Add(AttendanceSession session);
        void Update(AttendanceSession session);
        void Delete(int id);
        AttendanceSession? GetById(int id);
        List<AttendanceSession> GetAll();
        AttendanceSession? GetByQRCodeToken(string token);
        List<AttendanceSession> GetByCourseId(int courseId);
    }

}
