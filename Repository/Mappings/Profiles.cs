using AutoMapper;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Mappings
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Attraction, Attraction>()
                .ForMember(dest => dest.AttractionId, opt => opt.Ignore());

            CreateMap<Availability, Availability>()
                .ForMember(dest => dest.AvailabilityId, opt => opt.Ignore());

            CreateMap<Branch, Branch>()
                .ForMember(dest => dest.BranchId, opt => opt.Ignore());

            CreateMap<Comment, Comment>()
                .ForMember(dest => dest.CommentId, opt => opt.Ignore());

            CreateMap<Route, Route>()
                .ForMember(dest => dest.RouteId, opt => opt.Ignore());

            CreateMap<Trip, Trip>()
                .ForMember(dest => dest.TripId, opt => opt.Ignore());

            CreateMap<User, User>()
                .ForMember(dest => dest.UserId, opt => opt.Ignore());

        }
    }
}
