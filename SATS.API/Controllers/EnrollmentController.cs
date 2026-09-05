using System;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SATS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : BaseController
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(ILogger<EnrollmentController> logger, IEnrollmentService service)
            : base(logger) => _enrollmentService = service;

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var enrollments = _enrollmentService.GetAllEnrollments();
                return HandleResponse(enrollments);
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to retrieve enrollments.");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var enrollment = _enrollmentService.GetEnrollmentById(id);
                return HandleResponse(enrollment);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve enrollment with ID: {id}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] EnrollmentDto enrollmentDto)
        {
            try
            {
                if (enrollmentDto == null)
                    return BadRequest(new { message = "Invalid enrollment data.", success = false });

                _enrollmentService.CreateEnrollment(enrollmentDto);
                return HandleResponse(new { message = "Enrollment created successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create enrollment.");
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] EnrollmentDto enrollmentDto)
        {
            try
            {
                if (enrollmentDto == null)
                    return BadRequest(new { message = "Invalid enrollment data.", success = false });

                enrollmentDto.EnrollmentId = id;
                _enrollmentService.UpdateEnrollment(enrollmentDto);
                return HandleResponse(new { message = "Enrollment updated successfully.", success = true });
            }
            catch (ArgumentException)
            {
                return NotFound(new { message = "Enrollment not found to update.", success = false });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to update enrollment.");
            }
        }
    }
}
