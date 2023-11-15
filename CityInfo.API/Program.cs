
using CityInfo.API.DbContexts;
using CityInfo.API.services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;

namespace CityInfo.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*  Log.Logger = new LoggerConfiguration()
                  .MinimumLevel.Debug()
                  .WriteTo.Console()
                  .WriteTo.File("logs/cityInfo.txt", rollingInterval: RollingInterval.Day)
                  .CreateLogger();  */
            var builder = WebApplication.CreateBuilder(args);

            // builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

            // Add services to the container.

            builder.Services.AddTransient<IMailservice, LocalMailservice>();
            builder.Services.AddSingleton<CitiesDataStore>();

            builder.Services.AddScoped<ICityInfoRepository, CityInfoRepository>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); 


            builder.Services.AddControllers(options =>
            {
                options.ReturnHttpNotAcceptable = true;
            })
              .AddXmlDataContractSerializerFormatters();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
  

            builder.Services.AddDbContext<CityInfoContext>(options => options.UseSqlServer(
               builder.Configuration.GetConnectionString("DefaultConnection")
            ));

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}