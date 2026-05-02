using Common.Dto;
using Microsoft.Extensions.DependencyInjection;
using Repository.Entities;
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
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRepository<Route>, RouteRepository>();
            services.AddScoped<IRepository<Attraction>, AttractionRepository>();
            services.AddScoped<IAvailabilityRepository, AvailabilityRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            services.AddScoped<ITripService, TripService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IService<RouteDto>, RouteService>();
            services.AddScoped<IService<AttractionDto>, AttractionService>();
            services.AddScoped<IAvailabilityService, AvailabilityService>();
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<ICommentService, CommentService>();

            services.AddScoped<IsExist<TripDto>, TripService>();
            services.AddScoped<IsExist<UserDto>, UserService>();
            services.AddScoped<IsExist<RouteDto>, RouteService>();
            services.AddScoped<IsExist<AttractionDto>, AttractionService>();
            services.AddScoped<IsExist<AvailabilityDto>, AvailabilityService>();
            services.AddScoped<IsExist<BranchDto>, BranchService>();
            services.AddScoped<IsExist<CommentDto>, CommentService>();

            return services;
        }
    }
}
