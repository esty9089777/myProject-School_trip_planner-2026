using System.Security.Cryptography.X509Certificates;

namespace Repository.Entities
{
    public enum Direction
    {
        North,  //צפון
        South, //דרום
        East, //מזרח
        West //מערב
    }
    public class Location
    {
        public int LocationId { get; set; }
        public string NameCity { get; set; }
        public Direction direction { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public ICollection<Routes> RoutesList { get; set; }
        public ICollection<Branches> BranchesList { get; set; }
    }
}
