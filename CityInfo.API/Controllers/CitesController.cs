using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitesController : ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper; 



        public CitesController(
        ICityInfoRepository cityInfoRepository,
        IMapper mapper
            ) { 
            _cityInfoRepository = cityInfoRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithOutPointOfInterestDto>>> GetCities()
        { 
            var cityEntities = await _cityInfoRepository.GetCitiesAsync();
          
            
           var results =  new List<CityWithOutPointOfInterestDto>();
            foreach ( var city in cityEntities )
           {
              results.Add( new CityWithOutPointOfInterestDto() 
               {
                   Id = city.Id,
                   Name = city.Name,
                  Description = city.Description,
                });   
           }
            //   return  Ok(_mapper.Map<IEnumerable<CityWithOutPointOfInterestDto>>(cityEntities));
            return Ok(results);
        }

        /*     [HttpGet("{id}")]
             public ActionResult<CityDto> GetCity(int Id)
             {
                 var cityToReturn = _citiesDataStore.Cities
                     .FirstOrDefault(c => c.Id == Id);

                 if (cityToReturn == null)
                 {
                     return NotFound();
                 }
                 return Ok(cityToReturn);
             }
         */
    }

}
