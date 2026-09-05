using Application.DTOs;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IAttendanceSessionService
    {
        void CreateAttendanceSession(AttendanceSessionDto AttendanceSessionDto);
        void UpdateAttendanceSession(AttendanceSessionDto attendanceSessionDto);
        AttendanceSessionDto? GetAttendanceSessionById(int id);
        IEnumerable<AttendanceSessionDto> GetAllAttendanceSessions();
    }

}
