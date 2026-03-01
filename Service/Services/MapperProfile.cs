using AutoMapper;
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
        }

        public byte[] myConvert(string url)
        {
            string path = Environment.CurrentDirectory + "/Images/" + url;
            var arr = File.ReadAllBytes(path);
            return arr;
        }
    }
}
