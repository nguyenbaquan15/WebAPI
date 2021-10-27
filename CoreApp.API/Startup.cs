using AutoMapper;
using CoreApp.Model.DBContext;
using CoreApp.Model.Respository;
using CoreApp.Model.UnitOfWork;
using CoreApp.Service.AutoMaper;
using CoreApp.Service.Implement;
using CoreApp.Service.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.API
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

            services.AddControllers();

            /*-------------------------------------------------------------------*/
            //AutoMapper
            services.AddAutoMapper(typeof(MappingProfile));
            
            /*-------------------------------------------------------------------*/



            /*----------------------------------------------------------------------------------*/
            // User code: Depend injection:

            services.AddTransient(typeof(IGenericRespository<>), typeof(GenericRespository<>));
            //services.AddSingleton<CoreAppDbContext>();
            services.AddScoped<CoreAppDbContext>();

            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<IBookingOfficeService, BookingOfficeService>();
            services.AddTransient<IPackingLotService, PackingLotService>();
            services.AddTransient<ITicketService, TicketService>();
            services.AddTransient<ITripService, TripService>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            /*----------------------------------------------------------------------------------*/


            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CoreApp.API", Version = "v1" });
            //});


            /*-----------------------------------------------------------------------------------------*/
            //User code: Authencation

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo() { Title = "WebAPI", Version = "v1" });
                config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                config.AddSecurityRequirement(new OpenApiSecurityRequirement
{
{
                new OpenApiSecurityScheme
                {
                Reference = new OpenApiReference
                {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
                }
                },
                Array.Empty<string>()
                }
                });
            });

            var tokenKey = Configuration.GetValue<string>("TokenKey");
            // var tokenKey = "This is my test private key";

            var key = Encoding.ASCII.GetBytes(tokenKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSingleton<IAuthencationService>(new AuthencationService(tokenKey));


            /*-----------------------------------------------------------------------------------------*/
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoreApp.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            /*--------------------------------------*/

            app.UseAuthentication();

            /*--------------------------------------*/

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
