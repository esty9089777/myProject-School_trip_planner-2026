using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public class AvailabilityDto
    {
        public int AvailabilityId { get; set; }
        public int AttractionOrRouteId { get; set; }
        public System.DayOfWeek Day { get; set; }
        public TimeOnly OpenTime { get; set; }
        public TimeOnly CloseTime { get; set; }
    }
}
