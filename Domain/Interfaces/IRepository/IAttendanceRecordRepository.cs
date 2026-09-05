using Domain.Entities;
using System.Collections.Generic;
using System;

namespace Domain.Interfaces.IRepository
{
    public interface IAttendanceRecordRepository
    {
        void Add(AttendanceRecord record);
        void Update(AttendanceRecord record);
        void Delete(int id);
        AttendanceRecord? GetById(int id);
        List<AttendanceRecord> GetAll();
        AttendanceRecord? GetByStudentAndSession(int studentId, int sessionId);
        List<AttendanceRecord> GetBySessionId(int sessionId);
        bool Exists(int studentId, int sessionId);
    }

}
