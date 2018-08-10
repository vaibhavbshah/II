using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using II.ContollerHelpers;
using AutoMapper;
using Repository;
using Managers;
using Microsoft.IdentityModel.Tokens;
using Entities;

namespace II
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddAutoMapper();
            
            var config = new MapperConfiguration(cfg =>
             {
                 cfg.CreateMap<EnvironmentConfiguration, Common.Configuration.EnvironmentConfiguration>();
                 cfg.CreateMap<Customer,User>();
             });
            var mapper = config.CreateMapper();
            services.AddCors();

            services.AddAuthentication(
                cfg => {
                    cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
                )
             .AddJwtBearer(options => {
                 options.TokenValidationParameters =
                      new TokenValidationParameters
                      {
                          ValidateIssuer = true,
                          ValidateAudience = true,
                          ValidateLifetime = true,
                          ValidateIssuerSigningKey = true,

                          ValidIssuer = Configuration["Jwt:Issuer"],
                          ValidAudience = Configuration["Jwt:Issuer"],
                          IssuerSigningKey =
                           JwtSecurityKey.Create("fiversecretfiversecretfiversecretfiversecret")
                      };

                 options.Events = new JwtBearerEvents
                 {
                     OnAuthenticationFailed = context =>
                     {
                         Console.WriteLine("OnAuthenticationFailed: " +
                             context.Exception.Message);
                         return Task.CompletedTask;
                     },
                     OnTokenValidated = context =>
                     {
                         Console.WriteLine("OnTokenValidated: " +
                             context.SecurityToken);
                         return Task.CompletedTask;
                     }
                 };
             });

            //services.AddCors(options => options.WithOrigins("http://localhost:4200")
            //                                                                .AllowAnyOrigin()
            //                                                                .AllowAnyMethod()
            //                                                                .AllowAnyOrigin()));
            // Add framework services.
            services.AddMvc();
            services.AddSingleton<IMapper>(mapper);
            services.AddTransient<IEnvironmentConfiguration, EnvironmentConfiguration>();
            services.AddTransient<CustomerManager, CustomerManager>();
            services.AddTransient<AuthenticationManager, AuthenticationManager>();
            services.AddSingleton<IDBConfiguration, EnvironmentConfiguration>();
            services.AddSingleton<IConfiguration>(Configuration);

            services.Configure<Common.Configuration.EnvironmentConfiguration>(Configuration.GetSection("DBConfiguration"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors(
                options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()
            );

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
