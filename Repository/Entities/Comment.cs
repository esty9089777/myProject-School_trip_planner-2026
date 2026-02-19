using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public int RouteId { get; set; }
        public Route Route { get; set; }
        public string myComment { get; set; }
        public string SchoolName { get; set; }
        public DateOnly DateCommon { get; set; }
    }
}
