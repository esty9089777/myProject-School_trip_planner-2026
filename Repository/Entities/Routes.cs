using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class Routes
    {
        public int RouteId { get; set; }
        public string RouteName { get; set; }
        public bool IsFree { get; set; }
        public bool IsWet { get; set; }
        public TimeOnly Duration { get; set; }
        public AgeGroup AgeGroup { get; set; } 
        [ForeignKey("AgeGroup")]
        public string Description { get; set; }
        public bool IsOpen { get; set; }
        public Location Location { get; set; }
        public AttractionCategoryEnum routeCategory { get; set; }
        public Comments Comments { get; set; }
        public string ImageUrl { get; set; }
        public int Points { get; set; } //מוגבל ל-5

        public ICollection<RouteAvailability> RouteAvailabilities { get; set; }
        public ICollection<Comments> CommentsList { get; set; }
    }
}
