

namespace Common.Dto
{
    public class RouteDto
    {
        public int RouteId { get; set; }
        public string RouteName { get; set; }
        public bool IsFree { get; set; }
        public bool IsWet { get; set; }
        public TimeOnly Duration { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Points { get; set; }
        public int CreatorId { get; set; }
    }
}
