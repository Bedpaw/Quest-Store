using System;
using System.Reflection;
using System.Security.Claims;
using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using QuestStore.API.GenericControllersFactory;
using QuestStore.Infrastructure.Data;
using QuestStore.Core;
using QuestStore.Core.Interfaces;
using QuestStore.Core.Services;
using QuestStore.Infrastructure.Data.Repository;

namespace QuestStore.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(o => o.Conventions.Add(new ControllersRouteConvention()))
                .ConfigureApplicationPartManager(
                    manager => manager.FeatureProviders.Add(new ControllersFeatureProvider()))
                .AddNewtonsoftJson(
                    o =>
                    {
                        o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                        o.SerializerSettings.Converters.Add(new StringEnumConverter());
                    })
                // Adds proper QuestType to swagger docs.
                .AddJsonOptions(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.AddDbContext<StoreDbContext>(
                options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("Default"));

                    if (Environment.IsDevelopment())
                    {
                        options.EnableSensitiveDataLogging().EnableDetailedErrors();
                    }
                });

            services.AddCors(
                options =>
                {
                    options.AddPolicy(
                        "CorsDevelopmentPolicy",
                        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

                    options.AddPolicy(
                        "CorsReleasePolicy",
                        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
                });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Quest Store API",
                    Version = "v1",
                    Description = ""
                });
                options.TagActionsBy(api =>
                {
                    if (api.GroupName != null)
                    {
                        return new[] { api.GroupName };
                    }
                    if (api.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
                    {
                        return new[] { controllerActionDescriptor.ControllerName };
                    }
                    throw new InvalidOperationException("Unable to determine tag for endpoint.");
                });
                // It includes the action in the document regardless of its group name
                options.DocInclusionPredicate((name, api) => true);
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(
                    options =>
                    {
                        options.Authority = $"https://{Configuration["Auth0:Domain"]}/";
                        options.Audience = Configuration["Auth0:Audience"];
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            NameClaimType = ClaimTypes.NameIdentifier,
                            RoleClaimType = ClaimTypes.Role
                        };
                    });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(ILinkingRepository<>), typeof(LinkingRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IStudentService, StudentService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Quest Store API");
                options.RoutePrefix = "";
            });

            app.UseHttpsRedirection();

            app.UseCors(Environment.IsDevelopment() ? "CorsDevelopmentPolicy" : "CorsReleasePolicy");

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}