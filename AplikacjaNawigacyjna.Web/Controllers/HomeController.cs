using AplikacjaNawigacyjna.Web.Models;
using AplikacjaNawigacyjna.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AplikacjaNawigacyjna.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapPointService _mapPointService;
        private readonly IRouteService _routeService;
        private readonly ITrafficService _trafficService;
        private readonly IPOIService _poiService;
        private readonly IRouteHistoryService _routeHistoryService;

        public HomeController(IMapPointService mapPointService, IRouteService routeService, ITrafficService trafficService, IPOIService poiService, IRouteHistoryService routeHistoryService)
        {
            _mapPointService = mapPointService;
            _routeService = routeService;
            _trafficService = trafficService;
            _poiService = poiService;
            _routeHistoryService = routeHistoryService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new ViewModel();
            List<MapPointDto> mapPoints = new();
            ResponseDto? responsePoints= await _mapPointService.GetAllMapPointsAsync();
            if (responsePoints != null && responsePoints.IsSuccess)
            {
                mapPoints = JsonConvert.DeserializeObject<List<MapPointDto>>(Convert.ToString(responsePoints.Result));
            }
            model.locations = mapPoints;
            return View(model);
        }

        public async Task<IActionResult> AddMapPoint()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddMapPoint(MapPointDto dto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _mapPointService.CreateMapPointAsync(dto);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(dto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMapPoint(string code)
        {
            ResponseDto? response = await _mapPointService.DeleteMapPointAsync(code);
            if (response != null && response.IsSuccess)
                return Ok();
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> EditMapPoint(string code, string newName)
        {

            var response = await _mapPointService.GetMapPointByCode(code);
            if (response != null && response.IsSuccess)
            {
                if (ModelState.IsValid)
                {
                    MapPointDto mapPoint = JsonConvert.DeserializeObject<MapPointDto>(response.Result.ToString());
                    mapPoint.Name = newName;
                    var updateResponse = await _mapPointService.UpdateMapPointAsync(mapPoint);
                    if (updateResponse != null && updateResponse.IsSuccess)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public async Task<IActionResult> CalculateRoute([FromBody] RouteDto request)
        {
            var routeRequest = new RouteRequestDto
            {
                Origin = request.Origin,
                Destination = request.Destination
            };
            var response = await _routeService.Calculate(routeRequest);
            if (response != null && response.Result != null)
            {
                RouteResponseDto result = JsonConvert.DeserializeObject<RouteResponseDto>(response.Result.ToString());

                var routeRecord = new RouteRecordDto
                {
                    Code = "code",
                    StartName = request.StartName,
                    EndName = request.EndName,
                    StartLatitude = request.Origin.Latitude,
                    StartLongitude = request.Origin.Longitude,
                    EndLatitude = request.Destination.Latitude,
                    EndLongitude = request.Destination.Longitude,
                    Distance = result.DistanceInMeters
                };
                await _routeHistoryService.CreateRouteRecordAsync(routeRecord);

                return Json(new
                {
                    path = result.Path.Select(p => new { latitude = p.Latitude, longitude = p.Longitude }),
                    distanceInMeters = result.DistanceInMeters
                });
            }

            return Json(new { path = new List<object>(), distanceInMeters = 0 });
        }

        [HttpPost]
        public async Task<IActionResult> GetTrafficEvents([FromBody] BboxDto dto)
        {    
            var response = await _trafficService.GetAllEventsAsync(dto);
            List<TrafficEventDto> trafficEvents = new();
            if (response != null && response.IsSuccess)
            {
                trafficEvents = JsonConvert.DeserializeObject<List<TrafficEventDto>>(Convert.ToString(response.Result));
            }
            return Ok(trafficEvents);

        }

        [HttpPost]
        public async Task<IActionResult> GetPOIs([FromBody] BboxDto dto)
        {
            var response = await _poiService.GetAllPOI(dto);
            List<PointOfInterestDto> trafficEvents = new();

            if (response != null && response.IsSuccess)
            {
                trafficEvents = JsonConvert.DeserializeObject<List<PointOfInterestDto>>(Convert.ToString(response.Result));
            }
            return Ok(trafficEvents);

        }

    }
}
