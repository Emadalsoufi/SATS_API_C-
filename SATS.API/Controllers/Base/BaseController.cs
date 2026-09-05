using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SATS.API.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly ILogger Logger;

        protected BaseController(ILogger logger)
        {
            Logger = logger;
        }

        protected IActionResult Execute(Func<IActionResult> action)
        {
            try { return action(); }
            catch (ArgumentNullException ex) { return BadRequest(new { message = ex.Message, success = false }); }
            catch (ArgumentException ex) { return NotFound(new { message = ex.Message, success = false }); }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Unhandled API error.");
                return StatusCode(500, new { message = "An unexpected error occurred.", success = false });
            }
        }

        protected IActionResult HandleResponse<T>(T result, string? message = null)
        {
            if (result == null)
            {
                Logger.LogWarning("Requested resource not found.");
                return NotFound(new
                {
                    message = "Resource not found.",
                    success = false
                });
            }

            var msgProp = result.GetType().GetProperty("Message");
            if (msgProp != null && message != null)
            {
                var currentValue = msgProp.GetValue(result);
                if (currentValue == null)
                    msgProp.SetValue(result, message);
            }

            return Ok(result);
        }

        protected IActionResult HandleError(Exception ex, string message = "An unexpected error occurred.")
        {
            Logger.LogError(ex, message);

            return StatusCode(500, new
            {
                message = message,
                success = false,
                error = ex.Message
            });
        }
    }
}
