using System;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SATS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : BaseController
    {
        private readonly ICourseService _courseService;

        public CourseController(ILogger<CourseController> logger, ICourseService service)
            : base(logger) => _courseService = service;

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var courses = _courseService.GetAllCourses();
                return HandleResponse(courses);
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to retrieve courses.");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var course = _courseService.GetCourseById(id);
                return HandleResponse(course);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve course with ID: {id}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CourseDto courseDto)
        {
            try
            {
                if (courseDto == null)
                    return BadRequest(new { message = "Invalid course data.", success = false });

                _courseService.CreateCourse(courseDto);
                return HandleResponse(new { message = "Course created successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create course.");
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] CourseDto courseDto)
        {
            try
            {
                if (courseDto == null)
                    return BadRequest(new { message = "Invalid course data.", success = false });

                courseDto.CourseId = id;
                _courseService.UpdateCourse(courseDto);
                return HandleResponse(new { message = "Course updated successfully.", success = true });
            }
            catch (ArgumentException)
            {
                return NotFound(new { message = "Course not found to update.", success = false });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to update course.");
            }
        }
    }
}
