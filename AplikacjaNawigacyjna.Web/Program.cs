using AplikacjaNawigacyjna.Web.Services;
using AplikacjaNawigacyjna.Web.Services.IServices;
using AplikacjaNawigacyjna.Web.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

builder.Services.AddHttpClient<ILocationService, LocationService>();
builder.Services.AddHttpClient<IMapPointService, MapPointService>();
builder.Services.AddHttpClient<IRouteService, RouteService>();
builder.Services.AddHttpClient<ITrafficService, TrafficService>();
builder.Services.AddHttpClient<IPOIService, POIService>();
SD.LocationAPIBase = builder.Configuration["ServiceUrls:LocationAPI"];
SD.MapPointAPIBase = builder.Configuration["ServiceUrls:MapPointAPI"];
SD.RouteAPIBase = builder.Configuration["ServiceUrls:RouteAPI"];
SD.TrafficAPIBase = builder.Configuration["ServiceUrls:TrafficAPI"];
SD.POIAPIBase = builder.Configuration["ServiceUrls:POIAPI"];
builder.Services.AddScoped<IMapPointService, MapPointService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IRouteService, RouteService>();
builder.Services.AddScoped<ITrafficService, TrafficService>();
builder.Services.AddScoped<IPOIService, POIService>();
builder.Services.AddScoped<IBaseService, BaseService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
    app.UseExceptionHandler("/Home/Error");

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
