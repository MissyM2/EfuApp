using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfuApp.CoreBusiness
{
    public class WeekAssessment
    {
        public int WeekAssessmentId { get; set; }

        public int CourseId { get; set; }

        public Course? Course { get; set; } = null!;

        [Required]
        public int WeekNumber { get; set; }

        //[Required]
        //public string DoneBy { get; set; } = string.Empty;

        public string LikedLeast { get; set; } = null!;

        public string LikedMost { get; set; } = null!;
        public string MostDifficult { get; set; } = null!;
        public string LeastDifficult { get; set; } = null!;
    }

}
