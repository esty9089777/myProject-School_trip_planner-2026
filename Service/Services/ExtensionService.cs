//using Common.Dto;
using Microsoft.Extensions.DependencyInjection;
using Repository.Interfaces;
using Repository.Repositories;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public static class ExtensionService
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITripRepository, TripRepository>();

            services.AddScoped<ITripService, TripService>();

            // אם יש לך שירות משתמשים:
            // services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
