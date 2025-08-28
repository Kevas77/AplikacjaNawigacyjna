using AplikacjaNawigacyjna.Services.MapApi.Data;
using AplikacjaNawigacyjna.Services.MapApi.Models;
using AplikacjaNawigacyjna.Services.MapApi.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AplikacjaNawigacyjna.Services.MapApi.Controllers
{
    [Route("api/mappoint")]
    [ApiController]
    public class MapPointApiController : ControllerBase
    {
        private readonly AppDbContext _context;
        private ResponseDto _response;
        private IMapper _mapper;

        public MapPointApiController(AppDbContext context, IMapper mapper)
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
                IEnumerable<MapPoint> objList = _context.MapPoints.ToList();
                _response.Result = _mapper.Map<IEnumerable<MapPointDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetMapPoint(string code)
        {
            try
            {
                MapPoint obj = _context.MapPoints.First(u => u.Code == code);
                _response.Result = _mapper.Map<MapPointDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public ResponseDto AddMapPoint([FromBody] MapPointDto dto)
        {
            try
            {
                dto.Code = Guid.NewGuid().ToString();
                MapPoint obj = _mapper.Map<MapPoint>(dto);
                _context.MapPoints.Add(obj);
                _context.SaveChanges();

                _response.Result = _mapper.Map<MapPointDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        public ResponseDto Update([FromBody] MapPointDto dto)
        {
            try
            {
                MapPoint obj = _mapper.Map<MapPoint>(dto);
                _context.MapPoints.Update(obj);
                _context.SaveChanges();

                _response.Result = _mapper.Map<MapPointDto>(obj);
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
                MapPoint obj = _context.MapPoints.First(u => u.Code == code);
                _context.MapPoints.Remove(obj);
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
