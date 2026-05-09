using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public class TripRequestDto
    {
        public DateTime TripDate { get; set; }
        public int DurationInHours { get; set; }
        public Direction direction { get; set; }
        public decimal MaxBudgetPerStudent { get; set; }
        public bool IsWet { get; set; }
        public string DifficultyLevel { get; set; }
        public string FreeTextNotes { get; set; }
    }
}
