using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public enum AgeGroupEnum
    {
        AtoC = 1,   // כיתות א-ג
        DtoE = 2,   // כיתות ד-ה
        FtoH = 4,   // כיתות ו-ח
        ItoL = 8    // כיתות ט-יב
    }

    [Flags]
    public enum Direction
    {
        North = 1,
        Haifa = 2,
        Jerusalem = 4,
        Center = 8,
        South = 16,
        Golan = 32,
        Galilee = 64,
        Negev = 128,
        Sharon = 256
    }
    public class Route
    {
        public int RouteId { get; set; }
        public string RouteName { get; set; }
        public bool IsFree { get; set; }
        public bool IsWet { get; set; }
        public TimeOnly Duration { get; set; }
        public AgeGroupEnum AgeGroup { get; set; } 
        public string Description { get; set; }
        public AttractionCategoryEnum routeCategory { get; set; }
        public string ImageUrl { get; set; }
        public int Points { get; set; } 
        public Direction direction { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public ICollection<List<Availability>> RouteAvailabilities { get; set; }
        public ICollection<Comment> CommentsList { get; set; }
    }
}
