using AplikacjaNawigacyjna.Services.TrafficApi.Models;
using AplikacjaNawigacyjna.Services.TrafficApi.Models.DTOs;
using AplikacjaNawigacyjna.Services.TrafficApi.Services.IServices;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AplikacjaNawigacyjna.Services.TrafficApi.Controllers
{
    [Route("api/traffic")]
    [ApiController]
    public class TrafficApiController : ControllerBase
    {
        private readonly ITrafficService _service;
        private ResponseDto _response;

        public TrafficApiController(ITrafficService service)
        {
            _service = service;
            _response = new ResponseDto();
        }

        [HttpPost]
        public async Task<IActionResult> GetAllEvents([FromBody]BboxDto dto)
        {
            try
            {
                _response.Result = await _service.GetAllEventsAsync(dto);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return Ok(_response);
            
        }
    }
}
