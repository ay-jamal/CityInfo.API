
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.DbContexts
{
    public class CityInfoContext : DbContext
    {
        public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options)
        {
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointOfInterest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City("new york")
                {
                    Id = 1,
                    Description = "Demo"
                },
                   new City(" ajdabiya")
                   {
                       Id = 2,
                       Description = "Demo"
                   },
                    new City("benqazi")
                      {
                          Id = 3,
                          Description = "Demo"
                      }

                );

          /*  modelBuilder.Entity<PointOfInterest>().HasData(
                new PointOfInterest("one")
                {
                    Id=1,
                    CityId = 1,
                    Description = "test"
                },
                    new PointOfInterest("one")
                    {
                        Id = 2,
                        CityId = 1,
                        Description = "test"
                    },
                        new PointOfInterest("one")
                        {
                            Id = 3,
                            CityId = 2,
                            Description = "test"
                        },
                            new PointOfInterest("one")
                            {
                                Id = 4,
                                CityId = 3,
                                Description = "test"
                            }
                ); */
            base.OnModelCreating(modelBuilder);
        }
    }
}
