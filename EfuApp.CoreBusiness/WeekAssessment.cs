using EfuApp.CoreBusiness.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfuApp.CoreBusiness
{
    public class WeekAssessment : EntityBase
    {

        [Required]
        public int TermId { get; set; }

        public Term Term { get; set; } = null!;

        [Required]
        public int WeekNumber { get; set; }


        public string LikedLeast { get; set; } = null!;

        public string LikedMost { get; set; } = null!;
        public string MostDifficult { get; set; } = null!;
        public string LeastDifficult { get; set; } = null!;
    }

}
