using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities {  get; set; }

     //   public static CitiesDataStore Current { get; set; } = new CitiesDataStore();

        public CitiesDataStore() { 
        
        Cities = new List<CityDto>()
        {
            new CityDto(){
                Id = 1,
                Name = "Test",
                Description = "city Description",
                PointOfIntresets = new List<PointOfIntresetDto>()
                {
                    new PointOfIntresetDto()
                    {
                        Id = 1, 
                        Name = "point",
                        Description = "PointOfIntresetDto 1",
                    }
                }
            },
              new CityDto(){
                Id = 2,
                Name = "Test 2",
                Description = "city 2 Description",
                PointOfIntresets = new List<PointOfIntresetDto>()
                {
                    new PointOfIntresetDto()
                    {
                        Id = 2,
                        Name = "point",
                        Description = "PointOfIntresetDto 2",
                    }
                }
            },
                new CityDto(){
                Id = 3,
                Name = "Test 3",
                Description = "city 3 Description",
                PointOfIntresets = new List<PointOfIntresetDto>()
                {
                    new PointOfIntresetDto()
                    {
                        Id = 3,
                        Name = "point",
                        Description = "PointOfIntresetDto 3",
                    }
                }
            }
};
        }
    }
}
