using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCrudLearn.Data;

namespace WebApiCrudLearn.ExtentionsMethodes
{
    public static class ServicesExtentionsMethodes
    {

        public static IServiceCollection CustomController(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            return services;
        }

        public static IServiceCollection AddDbContextSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("applicationDbContext"));
            });
            return services;
        }
        public static IServiceCollection CustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiCrudLearn", Version = "v1" });
            });
            return services;
        }

        public static IServiceCollection AddDependencyInjectionRepositories(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddDependencyInjectionServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
