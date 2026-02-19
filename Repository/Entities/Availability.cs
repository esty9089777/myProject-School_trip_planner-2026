using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class Availability
    {
        public int AvailabilityId { get; set; }

        public int? AttractionId { get; set; }
        public Attraction Attraction { get; set; }
        public int? RouteId { get; set; }
        public Route Route { get; set; }
        public int? BranchId { get; set; }
        public Branch Branch { get; set; }

        public System.DayOfWeek Day { get; set; }

        public TimeOnly OpenTime { get; set; }
        public TimeOnly CloseTime { get; set; }
    }
}
