using AplikacjaNawigacyjna.Services.LocalizationAPI.Models.DTOs;
using AplikacjaNawigacyjna.Services.LocalizationAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AplikacjaNawigacyjna.Services.LocalizationAPI.Controllers
{
    [Route("api/location")]
    [ApiController]
    public class LocationApiController : ControllerBase
    {
        private readonly ILocationService _locationService;
        protected ResponseDto _response;

        public LocationApiController(ILocationService locationService)
        {
            _locationService = locationService;
            _response = new();
        }

        [HttpPost]
        public async Task<IActionResult> AddLocation(LocationDto dto)
        {
            try 
            {
                await _locationService.AddLocationAsync(dto);
                _response.IsSuccess = true;
            }
            catch
            {
                _response.IsSuccess = false;
            }
            return Ok(_response);
        }

        [HttpGet]
        [Route("current/{userId}")]
        public async Task<IActionResult> GetCurrent(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                _response.Message = "Nie podano identyfikatora użytkownika.";
                _response.IsSuccess = false;
                return BadRequest(_response);
            }

            var current = await _locationService.GetCurrentLocationAsync(userId);
            if (current == null)
            {
                _response.Message = "Brak zapisanej lokalizacji.";
                _response.IsSuccess = false;
                return NotFound(_response);
            }
            else
            {
                _response.IsSuccess = true;
                _response.Result = current;
            }
            return Ok(_response);
        }
    }
}
