using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public enum AttractionCategoryEnum
    {
        Park = 1,
        WaterPark,
        HistoricalSite,
        Archaeology,
        ReligiousSite,
        Museum,
        FunActivity,
        NatureReserve,
        HikingTrail
    }
    public class Branch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int AttractionId { get; set; }
        public Attraction Attraction { get; set; }
        public bool IsFree { get; set; }
        public bool IsWet { get; set; }
        public TimeOnly Duration { get; set; }
        public AgeGroupEnum AgeGroup { get; set; }
        public string Description { get; set; }
        public AttractionCategoryEnum attractionCategory { get; set; }
        public string ImageUrl { get; set; }
        public int Points { get; set; }
        public Direction direction { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public ICollection<Availability> RouteAvailabilities { get; set; } = new List<Availability>();
        public ICollection<Comment> CommentsList { get; set; }
    }
}
