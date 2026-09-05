using System;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SATS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceRecordController : BaseController
    {
        private readonly IAttendanceRecordService _attendanceRecordService;

        public AttendanceRecordController(ILogger<AttendanceRecordController> logger, IAttendanceRecordService service)
            : base(logger) => _attendanceRecordService = service;

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var records = _attendanceRecordService.AttendanceRecordServices();
                return HandleResponse(records);
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to retrieve attendance records.");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var record = _attendanceRecordService.GetAttendanceRecordServiceById(id);
                return HandleResponse(record);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve attendance record with ID: {id}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] AttendanceRecordDto recordDto)
        {
            try
            {
                if (recordDto == null)
                    return BadRequest(new { message = "Invalid attendance record data.", success = false });

                _attendanceRecordService.CreateAttendanceRecordService(recordDto);
                return HandleResponse(new { message = "Attendance record created successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create attendance record.");
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] AttendanceRecordDto recordDto)
        {
            try
            {
                if (recordDto == null)
                    return BadRequest(new { message = "Invalid attendance record data.", success = false });

                recordDto.RecordId = id;
                _attendanceRecordService.UpdateAttendanceRecordService(recordDto);
                return HandleResponse(new { message = "Attendance record updated successfully.", success = true });
            }
            catch (ArgumentException)
            {
                return NotFound(new { message = "Attendance record not found to update.", success = false });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to update attendance record.");
            }
        }
    }
}
