using AplikacjaNawigacyjna.Services.RouteApi.Models.DTOs;
using AplikacjaNawigacyjna.Services.RouteApi.Services.IServices;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AplikacjaNawigacyjna.Services.RouteApi.Controllers
{
    [Route("api/route")]
    [ApiController]
    public class RouteApiController : ControllerBase
    {
        private readonly IRouteService _calculator;
        private ResponseDto _response;

        public RouteApiController(IRouteService calculator)
        {
            _calculator = calculator;
            _response = new ResponseDto();
        }

        [HttpPost]
        public async Task<ActionResult<RouteResponseDto>> Post([FromBody] RouteRequestDto request)
        {
            try
            {
                if (request.Origin == null || request.Destination == null)
                    return BadRequest("Brakuje punktu startu lub mety.");

                var route = await _calculator.Calculate(request);

                _response.Result = route;
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
