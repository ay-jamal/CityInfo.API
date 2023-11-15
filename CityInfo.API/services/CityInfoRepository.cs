using CityInfo.API.DbContexts;
using CityInfo.API.Entities;
using System.Data.Entity;

namespace CityInfo.API.services
{
    public class CityInfoRepository : ICityInfoRepository
    {

        private readonly CityInfoContext _context;
        public CityInfoRepository(
            CityInfoContext context
            )
        {
            _context = context;
        }
        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _context.Cities.OrderBy(c=> c.Name).ToListAsync();   
        }

        public async Task<City?> GetCityAsync(int cityId, bool includePointOfIntreset)
        {

            if (includePointOfIntreset)
            {
                return await _context.Cities.Include(c => c.pointOfIntreset)
                    .Where(c => c.Id == cityId).FirstOrDefaultAsync();
            }
            return await _context.Cities
                    .Where(c => c.Id == cityId).FirstOrDefaultAsync();
        }

       public async Task<IEnumerable<PointOfInterest>> GetPointOfInterestsAsync(int cityId)
        {
            return await _context.PointOfInterest
                            .Where(p => p.CityId == cityId)
                            .ToListAsync();
        }

     public async Task<PointOfInterest?> GetPointOfInterestsForCityAsync(int cityId, int pointOfinterestId)
        {
            return await _context.PointOfInterest
                           .Where(p => p.CityId == cityId && p.Id == pointOfinterestId)
                           .FirstOrDefaultAsync();
        }
    }
}
