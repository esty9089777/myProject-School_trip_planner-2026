namespace Repository.Entities
{
    public class RouteAvailability
    {
        public int RouteAvailabilityId { get; set; }

        public int RouteId { get; set; }
        public Routes Route { get; set; }

        public DayOfWeekType Day { get; set; }

        public TimeOnly OpenTime { get; set; }  // שעת פתיחה של המסלול
        public TimeOnly CloseTime { get; set; } // שעת סגירה של המסלול
    }
}
