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
    public class Branches
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public bool IsFree { get; set; }
        public bool IsWet { get; set; }
        public TimeOnly Duration { get; set; }
        public AgeGroup AgeGroup { get; set; }
        [ForeignKey("AgeGroupId")]
        public string Description { get; set; }
        public bool IsOpen { get; set; }
        public Location Location { get; set; }
        public AttractionCategoryEnum attractionCategory { get; set; }
        public Comments Comments { get; set; }
        public string ImageUrl { get; set; }
        public int Points { get; set; } //מוגבל ל-5

        public ICollection<RouteAvailability> RouteAvailabilities { get; set; }
        public ICollection<Comments> CommentsList { get; set; }
    }
}
