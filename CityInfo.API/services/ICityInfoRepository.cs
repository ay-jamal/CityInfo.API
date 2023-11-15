using CityInfo.API.Entities;

namespace CityInfo.API.services
{
    public interface ICityInfoRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<City?> GetCityAsync(int cityId, bool includePointOfIntreset); 

        Task<IEnumerable<PointOfInterest>> GetPointOfInterestsAsync(int cityId);

        Task<PointOfInterest?> GetPointOfInterestsForCityAsync(int cityId, int pointOfinterestId);
     
    }
}
