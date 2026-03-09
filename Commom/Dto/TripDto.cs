using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public class TripDto
    {
        public int TripId { get; set; }

        public string UserName { get; set; } = null!;
        public string UserEmail { get; set; } = null!;

        public List<RouteDto> Routes { get; set; }
        public List<BranchDto> Branches { get; set; }
    }
}
