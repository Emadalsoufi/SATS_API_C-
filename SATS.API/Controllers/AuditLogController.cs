using System;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SATS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditLogController : BaseController
    {
        private readonly IAuditLogService _auditLogService;

        public AuditLogController(ILogger<AuditLogController> logger, IAuditLogService service)
            : base(logger) => _auditLogService = service;

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var logs = _auditLogService.GetAllAuditLogServices();
                return HandleResponse(logs);
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to retrieve audit logs.");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var log = _auditLogService.GetAuditLogServiceById(id);
                return HandleResponse(log);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve audit log with ID: {id}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] AuditLogDto auditLogDto)
        {
            try
            {
                if (auditLogDto == null)
                    return BadRequest(new { message = "Invalid audit log data.", success = false });

                _auditLogService.CreateAuditLogService(auditLogDto);
                return HandleResponse(new { message = "Audit log created successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create audit log.");
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] AuditLogDto auditLogDto)
        {
            try
            {
                if (auditLogDto == null)
                    return BadRequest(new { message = "Invalid audit log data.", success = false });

                auditLogDto.AuditLogId = id;
                _auditLogService.UpdateAuditLogService(auditLogDto);
                return HandleResponse(new { message = "Audit log updated successfully.", success = true });
            }
            catch (ArgumentException)
            {
                return NotFound(new { message = "Audit log not found to update.", success = false });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to update audit log.");
            }
        }
    }
}
