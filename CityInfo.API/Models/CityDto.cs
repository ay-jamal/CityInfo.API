namespace CityInfo.API.Models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }  = string.Empty;
        public string? Description { get; set; }

        public int NumberOfPointOfIntrest
        {
            get
            {
                return NumberOfPointOfIntrest;
            }
        }
        public ICollection<PointOfIntresetDto> PointOfIntresets { get; set;} = new List<PointOfIntresetDto>();
    }
}
