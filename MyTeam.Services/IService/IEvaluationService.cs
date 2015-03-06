using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTeam.Data;

namespace MyTeam.Services.IService
{
    
    interface IEvaluationService
    {

        // CREATE ===================================================================
        // addEvaluation
        void addEvaluation(Evaluation evaluation);

        // READ =====================================================================
        // getEvaluations
        IList<Evaluation> getEvaluations(int task);

        // getEvaluation
        Evaluation getEvaluation(int id);

        // UPDATE ===================================================================
        // editEvaluation
        void editEvaluation(Evaluation evaluation);

        // DELETE ===================================================================
        // deleteEvaluation
        void deleteEvaluation(Evaluation evaluation);

    }

}
