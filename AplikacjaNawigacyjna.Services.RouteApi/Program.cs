using AplikacjaNawigacyjna.Services.RouteApi.Services;
using AplikacjaNawigacyjna.Services.RouteApi.Services.IServices;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Access configuration via builder.Configuration
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddHttpClient<IRouteService, RouteService>(c =>
{
    c.BaseAddress = new Uri("https://api.openrouteservice.org/");
    c.DefaultRequestHeaders.Authorization =
      new AuthenticationHeaderValue("Bearer", configuration["OpenRouteService:ApiKey"]);
});
builder.Services.AddScoped<IRouteService, RouteService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
