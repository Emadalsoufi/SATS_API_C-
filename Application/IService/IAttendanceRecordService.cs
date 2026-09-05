using Application.DTOs;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IAttendanceRecordService
    {
        void CreateAttendanceRecordService(AttendanceRecordDto AttendanceRecordServiceDto);
        void UpdateAttendanceRecordService(AttendanceRecordDto attendanceRecordDto);
        AttendanceRecordDto? GetAttendanceRecordServiceById(int id);
        IEnumerable<AttendanceRecordDto> AttendanceRecordServices();
    }

}
