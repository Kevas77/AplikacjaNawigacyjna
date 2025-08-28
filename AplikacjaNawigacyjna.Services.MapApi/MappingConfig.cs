using AutoMapper;
using AplikacjaNawigacyjna.Services.MapApi.Models;
using AplikacjaNawigacyjna.Services.MapApi.Models.DTOs;

namespace AplikacjaNawigacyjna.Services.MapApi
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
                config.CreateMap<MapPointDto, MapPoint>().ReverseMap();
            }, loggerFactory);
            return mappingConfig;
        }
    }
}
