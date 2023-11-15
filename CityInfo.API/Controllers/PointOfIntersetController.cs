using CityInfo.API.Models;
using CityInfo.API.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/cities/{cityId}/pointofintreset")]
    [ApiController]
    public class PointOfIntersetController : ControllerBase

    {

        private readonly ILogger<PointOfIntersetController> _logger;
        private readonly IMailservice _mailService;
        private readonly CitiesDataStore _citiesDataStore;

        public PointOfIntersetController(
            ILogger<PointOfIntersetController> logger,
            IMailservice mailService,
            CitiesDataStore citiesDataStore
            
            )
        {
            _logger = logger;
            _mailService = mailService;
            _citiesDataStore = citiesDataStore;
            
        }


        [HttpGet]
        public ActionResult<IEnumerable<PointOfIntresetDto>> GetPointsOfIntresets(int? cityId)
        {
            var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
            if(cityId == null)
            {
                _logger.LogInformation("city not found");
                return NotFound();
            }
            return Ok(city?.PointOfIntresets);
        }

        [HttpGet("{pointOfInterestId}",Name ="GetPointOfInterest" )]
        public ActionResult<CityDto> GetPointOfIntreset(
           int? cityId,
           int pointOfIntresetId
            )
        {
            try
            {
                var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
                if (cityId == null)
                {
                    return NotFound();
                }
                var pointOfInterset = city?.PointOfIntresets.FirstOrDefault(c =>
                    c.Id == pointOfIntresetId
                    );

                if (pointOfInterset == null)
                {
                    return NotFound();
                }
                return Ok(pointOfInterset);
            }
            catch(Exception ex)
            {
                _logger.LogCritical("internal server error", ex);
                return StatusCode(500, "A problem happend while handeling the request");
            }
           
        }

        [HttpPost]
        public ActionResult<PointOfIntresetDto> createPointOfIntrest(
           int? cityId,  
           PointOfIntresetforCreationDto pointOfIntrest
            )
        {

            var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
            if (cityId == null)
            {
                return NotFound();
            }
            var maxPointOfInterest = _citiesDataStore.Cities
                .SelectMany(
                c => c.PointOfIntresets
                ).Max(p => p.Id);

            var finalPointOfInterest = new PointOfIntresetDto()
            {
                Id = ++maxPointOfInterest,
                Name = pointOfIntrest.Name,
                Description = pointOfIntrest.Description
            };

            city?.PointOfIntresets.Add(finalPointOfInterest);


            return CreatedAtRoute("GetPointOfInterest", new {
                cityId = cityId,
                pointOfInterest = finalPointOfInterest.Id

            },   
            finalPointOfInterest
            );

        }

        [HttpPut("{pontOfInterestId}")]
        public ActionResult UpdatingPointOfInterest(
            int? cityId,
            int pointOfInterestId,
            PointOfInterestForUpdatingDto pointOfIntersest
            )
        {
            var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
            if (cityId == null)
            {
                return NotFound();
            }

            var pointOfInterestForStore = city?.PointOfIntresets.FirstOrDefault(
               c => c.Id == pointOfInterestId
                );

            if (pointOfInterestForStore == null)
            {
                return NotFound();
            }

            if (pointOfInterestForStore != null)
            {
            pointOfInterestForStore.Name = pointOfIntersest.Name;
            pointOfInterestForStore.Description = pointOfIntersest.Description;
            }

            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeletePointOfInterest(int cityId , int pointOfInterestId)
        {

            var city = _citiesDataStore.Cities.FirstOrDefault(
                c => c.Id == cityId);

            var pointOfOnterestToDelete = city?.PointOfIntresets.FirstOrDefault(
                c => c.Id == pointOfInterestId
                );

            if(pointOfOnterestToDelete == null)
            {
                return NotFound();
            }
          city?.PointOfIntresets.Remove(pointOfOnterestToDelete);
        //    _mailService.Send("delete operation","the point is deleted");
            return NoContent();
        
        }

    }
}
