using AplikacjaNawigacyjna.Services.POIApi.Models.DTOs;
using AplikacjaNawigacyjna.Services.POIApi.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AplikacjaNawigacyjna.Services.POIApi.Controllers
{
    [Route("api/poi")]
    [ApiController]
    public class POIApiController : ControllerBase
    {
        private readonly IPOIService _poiService;
        private ResponseDto _response;
        public POIApiController(IPOIService poiService)
        {
            _poiService = poiService;
            _response = new ResponseDto();
        }
        [HttpPost]
        public async Task<IActionResult> GetAllPOI([FromBody] BboxDto dto)
        {
            try
            {
                _response.Result = await _poiService.GetAllPOI(dto);
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

