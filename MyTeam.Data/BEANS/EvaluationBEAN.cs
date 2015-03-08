using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeam.Data.BEANS
{
    
    public class EvaluationBEAN
    {
        public int Id { get; set; }
        public string Student { get; set; }
        public int TasksCompleted { get; set; }
        public int HighestMark { get; set; }
        public int LowestMark { get; set; }
        public float AverageMark { get; set; }
        
        // CONSTRUCTOR ===============================================================
        public EvaluationBEAN() { }

    }

}
