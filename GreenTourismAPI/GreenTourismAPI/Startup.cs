using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using GreenTourismAPI.Domain.Repositories;
using GreenTourismAPI.Domain.Services;
using GreenTourismAPI.Persistence;
using GreenTourismAPI.Persistence.Repositories;
using GreenTourismAPI.Services;

namespace GreenTourismAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<AppDbContext>(options => {
                options.UseInMemoryDatabase("green-tourism-api-in-memory");
            });

            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IFacilityRepository, FacilityRepository>();

            services.AddScoped<IPlaceService, PlaceService>();
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IFacilityService, FacilityService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
