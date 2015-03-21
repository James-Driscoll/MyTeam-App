using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyTeam.Data.BEANS
{
    
    public class EvaluationBEAN
    {
        public int Id { get; set; }
        public string Student { get; set; }
        [Display(Name = "Tasks Completed")]
        public int TasksCompleted { get; set; }
        [Display(Name = "Highest Mark")]
        public int HighestMark { get; set; }
        [Display(Name = "Lowest Mark")]
        public int LowestMark { get; set; }
        [Display(Name = "Average Mark")]
        public float AverageMark { get; set; }
        
        // CONSTRUCTOR ===============================================================
        public EvaluationBEAN() { }

    }

}
