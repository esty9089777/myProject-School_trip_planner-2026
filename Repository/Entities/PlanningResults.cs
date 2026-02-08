namespace Repository.Entities
{
    public class PlanningResults
    {
        public int PlanningResultId { get; set; }
        public bool IsApproved { get; set; }
        public TimeOnly TripDuration { get; set; }
        public int schoolId { get; set; }
    }
}
