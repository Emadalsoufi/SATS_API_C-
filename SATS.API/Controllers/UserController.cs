using System;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SATS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService service)
            : base(logger) => _userService = service;

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var users = _userService.GetAllUsers();
                return HandleResponse(users);
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to retrieve users.");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var user = _userService.GetUserById(id);
                return HandleResponse(user);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve user with ID: {id}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserDto userDto)
        {
            try
            {
                if (userDto == null)
                    return BadRequest(new { message = "Invalid user data.", success = false });

                _userService.CreateUser(userDto);
                return HandleResponse(new { message = "User created successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create user.");
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] UserDto userDto)
        {
            try
            {
                if (userDto == null)
                    return BadRequest(new { message = "Invalid user data.", success = false });

                userDto.UserId = id;
                _userService.UpdateUser(userDto);
                return HandleResponse(new { message = "User updated successfully.", success = true });
            }
            catch (ArgumentException)
            {
                return NotFound(new { message = "User not found to update.", success = false });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to update user.");
            }
        }
    }
}
