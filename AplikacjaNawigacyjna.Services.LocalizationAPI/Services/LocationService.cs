using AplikacjaNawigacyjna.Services.LocalizationAPI.Data;
using AplikacjaNawigacyjna.Services.LocalizationAPI.Models.DTOs;
using AplikacjaNawigacyjna.Services.LocalizationAPI.Services.IServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AplikacjaNawigacyjna.Services.LocalizationAPI.Services
{
    public class LocationService : ILocationService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IGeocodingService _geocodingService;

        public LocationService(AppDbContext context, IMapper mapper, IGeocodingService geocodingService)
        {
            _context = context;
            _mapper = mapper;
            _geocodingService = geocodingService;
        }

        public async Task AddLocationAsync(LocationDto dto)
        {
            var location = _mapper.Map<Models.Location>(dto);
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
        }

        public async Task<LocationDto?> GetCurrentLocationAsync(string userId)
        {
            var loc = await _context.Locations
                .Where(l => l.UserId == userId)
                .OrderByDescending(l => l.Timestamp)
                .FirstOrDefaultAsync();

            if (loc == null) return null;
            var dto = _mapper.Map<LocationDto>(loc);
            dto.Address = "Rynek Sanok";//await _geocodingService.GetAddressAsync(dto.Latitude, dto.Longitude);

            return dto;
        }


    }
}
