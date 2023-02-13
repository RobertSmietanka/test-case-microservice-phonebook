using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

using Phonebook.DTO;
using Phonebook.Microservice.Services;

namespace Phonebook.Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PhonebookController : ControllerBase
    {
        private readonly IAddressPointService _addressPointService;
        private readonly IMapper _mapper;
        private readonly ILogger<PhonebookController> _logger;

        public PhonebookController(IMapper mapper, IAddressPointService addressPointService, ILogger<PhonebookController> logger)
        {
            _mapper = mapper;
            _addressPointService = addressPointService;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<PhonebookResponse>> FindAddressPoint([FromBody] PhonebookRequest requestData)
        {
            if (string.IsNullOrEmpty(requestData.City))     // przykładowa walidacja
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            try
            {
                var addressPoint = await _addressPointService.FindAddressPointAsync(requestData);

                if (addressPoint == null)
                {
                    return NotFound();
                }

                var result = _mapper.Map<PhonebookResponse>(addressPoint);

                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Failed to find address point. {e.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError, e.StackTrace);
            }
        }
    }
}
