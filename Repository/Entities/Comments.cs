using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class Comments
    {
        public int CommentId { get; set; }
        public Branches Branch { get; set; }
        [ForeignKey("BranchId")]
        public Routes Routes { get; set; }
        [ForeignKey("RouteId")]
        public string Comment { get; set; }
        public string SchoolName { get; set; }
        public DateOnly Date_common { get; set; }
    }
}
