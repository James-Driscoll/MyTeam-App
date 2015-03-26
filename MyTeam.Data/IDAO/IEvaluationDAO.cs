using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeam.Data.IDAO
{
    
    interface IEvaluationDAO
    {
        
        // CREATE ====================================================================
        // addEvaluation
        void addEvaluation(Evaluation evaluation);

        // READ ======================================================================
        // getEvaluations
        IList<Evaluation> getEvaluations(int id);

        // getEvaluation
        Evaluation getEvaluation(int id);

        // getCompletedEvaluations
        IList<Evaluation> getCompletedEvaluations(string student, int project);

        // UPDATE ====================================================================
        // editEvaluation
        void editEvaluation(Evaluation evaluation);

        // DELETE ====================================================================
        // deleteEvaluation
        void deleteEvaluation(Evaluation evaluation);

    }

}

