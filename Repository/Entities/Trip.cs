using Repository.Interfaces;

namespace Repository.Entities
{
    public class Trip : IOwnable
    {
        public int TripId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public List<Route> Routes { get; set; }
        public List<Branch> Branches { get; set; }
        public int CreatorId => UserId;
    }
}
