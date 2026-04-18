using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public class BranchFilterDto
    {
        public bool? BranchName { get; set; }
        public Direction? Direction { get; set; }
        public AgeGroupEnum? AgeGroup { get; set; }
        public bool? IsFree { get; set; }
        public bool? IsWet { get; set; }
        public AttractionCategoryEnum? Category { get; set; }
    }
}
