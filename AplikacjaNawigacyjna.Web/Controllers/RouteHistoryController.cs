using AplikacjaNawigacyjna.Web.Models;
using AplikacjaNawigacyjna.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

public class RouteHistoryController : Controller
{
    private readonly IRouteHistoryService _routeHistoryService;

    public RouteHistoryController(IRouteHistoryService routeHistoryService)
    {
        _routeHistoryService = routeHistoryService;
    }

    public async Task<IActionResult> Index()
    {
        List<RouteRecordDto>? list = new();

        ResponseDto? response = await _routeHistoryService.GetRoutesHistoryAsync();

        if (response != null && response.IsSuccess)
        {
            list = JsonConvert.DeserializeObject<List<RouteRecordDto>>(Convert.ToString(response.Result));
        }
        else
        {
            TempData["error"] = response?.Message;
        }

        return View(list);
    }

    public async Task<IActionResult> Delete(string code)
    {
        var response = await _routeHistoryService.DeleteRouteRecordAsync(code);
        if (response != null && response.IsSuccess)
        {
            TempData["success"] = "Trasa zosta³a usuniêta.";
        }
        else
        {
            TempData["error"] = response?.Message ?? "B³¹d podczas usuwania trasy.";
        }
        return RedirectToAction(nameof(Index));
    }
}