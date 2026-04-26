using AutoMapper;
using Common.Dto;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mappings
{
    public class ServiceProfiles : Profile
    {
        public ServiceProfiles()
        {
            CreateMap<Attraction, AttractionDto>().ReverseMap();
            CreateMap<Availability, AvailabilityDto>().ReverseMap();
            CreateMap<Branch, BranchDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Route, RouteDto>().ReverseMap();
            CreateMap<Trip, TripDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<RegisterDto, User>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<ChangePasswordDto, User>();

            CreateMap<User, ResetPasswordDto>();
        }
    }
}
