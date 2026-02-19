namespace Repository.Entities
{
    public class Attraction
    {
        public int AttractionId { get; set; }
        public string AttraName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Branch> Branches { get; set; }
    }
}
