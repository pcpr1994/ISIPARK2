/*
 * Grupo 4
 * Trabalho II de ISI
 * Alunos
 *  Carlos Pereira nº6498
 *  Paula Rodrigues nº21133
 *  Sérgio Gonçalves nº20343
 *  
 */
using ISIParkAPI.Data;
using ISIParkAPI.Data.Repositories;
using ISIParkAPI.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace ISIParkAPI
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
            var mySQLConnectionConfig = new MySQLConfiguration(Configuration.GetConnectionString("MySqlConnection"));
            services.AddSingleton(mySQLConnectionConfig);

             //Add Authentication Service with JWT
             services.AddAuthentication
                 (JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(options =>
                  {
                      options.TokenValidationParameters = new TokenValidationParameters
                      {
                          ValidateIssuerSigningKey = true,

                        IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),

                       ValidateIssuer = false,
                       ValidateAudience = false
                     };
                 });

            //Add Services created in Repository
            services.AddScoped<IPersonalDataRepository, PersonalDataRepository>();
            services.AddScoped<IHistoryRepository, HistoryRepository>();
            services.AddScoped<IUserTypeRepository, UserTypeRepository>();
            services.AddScoped<IContactTypeRepository, ContactTypeRepository>();
            services.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
            services.AddScoped<ISectorRepository, SectorRepository>();
            services.AddScoped<IPlaceTypeRepository, PlaceTypeRepository>();
            services.AddScoped<IAdminMessageRepository, AdminMessageRepository>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserHistoryRepository, UserHistoryRepository>();
            services.AddScoped<IUserVechicleTypeRepository, UserVechicleTypeRepository>();
            services.AddScoped<IUserContactTypeRepository, UserContactTypeRepository>();
            services.AddScoped<IUserMessageRepository, UserMessageRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<ISpecialUsersRepository, SpecialUsersRepository>();
            services.AddScoped<IParkingSensorRepository, ParkingSensorRepository>();
            services.AddScoped<ILicensePlateSensorRepository, LicensePlateSensorRepository>();
            services.AddScoped<IQRCodeRepository, QRCodeRepository>();
            services.AddScoped<IBankRepository, BankRepository>();
   
            services.AddControllers();
            //Add Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ISIParkAPI",
                    Version = "v1",
                    Description = "ISIPark Swagger Documentation, this API it will be used by an Android application ISIPark",
                    Contact = new OpenApiContact() { Name = "Sérgio Rodrigues Pereira", Email = "isipark@gmail.com"},
                });
                
                //Add Comments for each endpoint on swagger
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                //Add Security Definition with JWT to Swagger
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the bearer scheme.\r\n\r\n " +
                    "Enter 'bearer'[space] and then your token in the text input below.\r\n\r\n" +
                    "Example: \"bearer 12345abcdef\""
                });
                c.OperationFilter<SecurityRequirementsOperationFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ISIParkAPI v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
