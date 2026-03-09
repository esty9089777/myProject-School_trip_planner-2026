using AutoMapper;
using Common.Dto;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class MapperProfile:Profile
    {
        string path = Directory.GetCurrentDirectory() + "/Images/";
        public MapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Route, RouteDto>().ReverseMap();
            CreateMap<Attraction, AttractionDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Availability, AvailabilityDto>().ReverseMap();
            CreateMap<Branch, BranchDto>();
        }

        public byte[] myConvert(string url)
        {
            string path = Environment.CurrentDirectory + "/Images/" + url;
            var arr = File.ReadAllBytes(path);
            return arr;
        }
    }
}
