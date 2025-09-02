using AplikacjaNawigacyjna.Services.RouteHistory.Models;
using AplikacjaNawigacyjna.Services.RouteHistory.Models.DTOs;
using AutoMapper;

namespace AplikacjaNawigacyjna.Services.RouteHistory
{
    public class MappingConfig
    {
        private static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
            builder.AddDebug();
        });
        public static MapperConfiguration RegisterMaps()
        {

            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<RouteRecordDto, RouteRecord>().ReverseMap();
            }, loggerFactory);
            return mappingConfig;
        }
    }
}
