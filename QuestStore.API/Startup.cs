using System.Reflection;
using System.Security.Claims;
using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            services.AddControllers(o => o.Conventions.Add(new GenericControllersRouteConvention()))
                .ConfigureApplicationPartManager(
                    manager => manager.FeatureProviders.Add(new GenericControllersFeatureProvider()))
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Quest Store API",
                    Version = "v1",
                    Description = ""
                });

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
                            RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
                        };
                    });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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