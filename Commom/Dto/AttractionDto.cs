using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public class AttractionDto
    {
        public int AttractionId { get; set; }
        public string AttraName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<BranchDto> Branches { get; set; }
        public int CreatorId { get; set; }
    }
}
