using AplikacjaNawigacyjna.Services.RouteHistory.Data;
using AplikacjaNawigacyjna.Services.RouteHistory.Models;
using AplikacjaNawigacyjna.Services.RouteHistory.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AplikacjaNawigacyjna.Services.RouteHistory.Controllers
{
    [Route("api/routehistory")]
    [ApiController]
    public class RouteHistoryApiController : ControllerBase
    {
        private readonly AppDbContext _context;
        private ResponseDto _response;
        private IMapper _mapper;

        public RouteHistoryApiController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _response = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDto GetAll()
        {
            try
            {
                IEnumerable<RouteRecord> objList = _context.RoutesHistory.ToList();
                _response.Result = _mapper.Map<IEnumerable<RouteRecordDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public ResponseDto AddRouteRecord([FromBody] RouteRecordDto dto)
        {
            try
            {
                dto.Code = Guid.NewGuid().ToString();
                RouteRecord obj = _mapper.Map<RouteRecord>(dto);
                _context.RoutesHistory.Add(obj);
                _context.SaveChanges();

                _response.Result = _mapper.Map<RouteRecordDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        [Route("{code}")]
        public ResponseDto Delete(string code)
        {
            try
            {
                RouteRecord obj = _context.RoutesHistory.First(u => u.Code == code);
                _context.RoutesHistory.Remove(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
