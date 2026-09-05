using System;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SATS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceSessionController : BaseController
    {
        private readonly IAttendanceSessionService _attendanceSessionService;

        public AttendanceSessionController(ILogger<AttendanceSessionController> logger, IAttendanceSessionService service)
            : base(logger) => _attendanceSessionService = service;

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var sessions = _attendanceSessionService.GetAllAttendanceSessions();
                return HandleResponse(sessions);
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to retrieve attendance sessions.");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var session = _attendanceSessionService.GetAttendanceSessionById(id);
                return HandleResponse(session);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve attendance session with ID: {id}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] AttendanceSessionDto sessionDto)
        {
            try
            {
                if (sessionDto == null)
                    return BadRequest(new { message = "Invalid attendance session data.", success = false });

                _attendanceSessionService.CreateAttendanceSession(sessionDto);
                return HandleResponse(new { message = "Attendance session created successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create attendance session.");
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] AttendanceSessionDto sessionDto)
        {
            try
            {
                if (sessionDto == null)
                    return BadRequest(new { message = "Invalid attendance session data.", success = false });

                sessionDto.SessionId = id;
                _attendanceSessionService.UpdateAttendanceSession(sessionDto);
                return HandleResponse(new { message = "Attendance session updated successfully.", success = true });
            }
            catch (ArgumentException)
            {
                return NotFound(new { message = "Attendance session not found to update.", success = false });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to update attendance session.");
            }
        }
    }
}
