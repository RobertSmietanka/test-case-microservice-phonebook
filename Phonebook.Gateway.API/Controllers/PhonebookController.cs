using Microsoft.AspNetCore.Mvc;
using System.Net;

using Phonebook.DTO;
using Phonebook.Gateway.WebAPI.Services;


namespace Phonebook.Gateway.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PhonebookController : ControllerBase
    {
        private readonly ILogger<PhonebookController> _logger;
        private readonly IPhonebookService _phonebookService;

        public PhonebookController(IPhonebookService phonebookService, ILogger<PhonebookController> logger)
        {
            _phonebookService = phonebookService;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> FindAddressPoint([FromBody] PhonebookRequest requestData)
        {
            try
            { 
                var addressPoint = await _phonebookService.FindAddressPointAsync(requestData);

                return Ok(addressPoint);
            }
            catch (HttpRequestException e)
            {
                _logger.LogError($"Failed to find address point. {e.Message}");

                return StatusCode(e.StatusCode.HasValue ? (int)e.StatusCode.Value : StatusCodes.Status500InternalServerError);
            }
        }
    }
}