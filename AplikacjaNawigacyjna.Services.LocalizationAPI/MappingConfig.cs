using AutoMapper;
using AplikacjaNawigacyjna.Services.LocalizationAPI.Models;
using AplikacjaNawigacyjna.Services.LocalizationAPI.Models.DTOs;

namespace Magisterka.Services.ProductAPI
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
                config.CreateMap<Location,LocationDto>();

                config.CreateMap<LocationDto, Location>()
                    .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => DateTime.UtcNow));
            }, loggerFactory);
            return mappingConfig;
        }
    }
}
