namespace Repository.Entities
{
    public enum DayOfWeekType
    {
        Sunday = 1,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }
    public class AttractionAvailability
    {
        public int AttractionAvailabilityId { get; set; }

        public int AttractionId { get; set; }
        public Attractions Attraction { get; set; }

        public DayOfWeekType Day { get; set; }  // איזה יום בשבוע

        public TimeOnly OpenTime { get; set; }  // שעת פתיחה כללית
        public TimeOnly CloseTime { get; set; } // שעת סגירה כללית
    }
}
