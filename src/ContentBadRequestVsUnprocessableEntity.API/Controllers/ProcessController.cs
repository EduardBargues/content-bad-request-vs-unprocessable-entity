using System;
using System.Net.Mail;
using System.Threading.Tasks;

using ContentBadRequestVsUnprocessableEntity.Services.Abstractions;

using Microsoft.AspNetCore.Mvc;

namespace ContentBadRequestVsUnprocessableEntity.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessController : ControllerBase
    {
        private readonly IProcessService _importService;

        public ProcessController(IProcessService importService)
        {
            _importService = importService ?? throw new ArgumentNullException(nameof(importService));
        }

        [HttpPost]
        public async Task<IActionResult> ImportAsync([FromQuery] string userId, [FromQuery] string accountId)
        {
            if (!IsInputValid(userId, accountId))
            {
                return BadRequest(ModelState);
            }

            var processId = await _importService.InitiateProcessAsync(userId, accountId);

            return Ok(new { processId = processId });
        }

        // A user id would be considered valid if is an email.
        private bool IsInputValid(string userId, string accountId)
        {
            bool validUser = IsUserIdValid(userId);
            bool validAccount = IsAccountIdValid(accountId);
            return validUser && validAccount;
        }

        // An acocunt id can not be a number.
        private bool IsAccountIdValid(string accountId)
        {
            bool isValid = !string.IsNullOrWhiteSpace(accountId) && !long.TryParse(accountId, out _);
            if (!isValid)
            {
                ModelState.AddModelError("accountId", "Invalid account id");
            }
            return isValid;
        }

        private bool IsUserIdValid(string userId)
        {
            try
            {
                var email = new MailAddress(userId);
                return true;
            }
            catch (FormatException)
            {
                ModelState.AddModelError("userId", "Invalid user id");
                return false;
            }
        }
    }
}
