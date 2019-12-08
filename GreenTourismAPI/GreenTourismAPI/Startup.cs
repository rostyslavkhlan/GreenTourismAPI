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
using GreenTourismAPI.Security.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using GreenTourismAPI.Domain.Security.Tokens;
using GreenTourismAPI.Domain.Security.Hashing;
using GreenTourismAPI.Security.Hashing;

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

            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<ITokenHandler, TokenHandler>();

            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IFacilityRepository, FacilityRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IPlaceService, PlaceService>();
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IFacilityService, FacilityService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.Configure<TokenOptions>(Configuration.GetSection("TokenOptions"));
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(jwtBearerOptions =>
                {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        IssuerSigningKey = signingConfigurations.Key,
                        ClockSkew = TimeSpan.Zero
                    };
                });

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

            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
