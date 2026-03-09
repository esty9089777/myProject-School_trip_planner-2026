using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public int BranchId { get; set; }
        public int RouteId { get; set; }
        public string myComment { get; set; }
        public string SchoolName { get; set; }
        public DateOnly DateCommon { get; set; }
    }
}
