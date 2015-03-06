using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTeam.Services.IService;
using MyTeam.Data;
using MyTeam.Data.DAO;

namespace MyTeam.Services.Service
{
   
    public class EvaluationService : IEvaluationService
    {

        private EvaluationDAO _evaluationDAO;
        public EvaluationService()
        {
            _evaluationDAO = new EvaluationDAO();
        }

        // CREATE ===================================================================
        // addEvaluation
        public void addEvaluation(Evaluation evaluation)
        {
            _evaluationDAO.addEvaluation(evaluation);
        }

        // READ =====================================================================
        // getEvaluations
        public IList<Evaluation> getEvaluations(int task)
        {
            return _evaluationDAO.getEvaluations(task);
        }

        // getEvaluation
        public Evaluation getEvaluation(int id)
        {
            return _evaluationDAO.getEvaluation(id);
        }

        // UPDATE ===================================================================
        // editEvaluation
        public void editEvaluation(Evaluation evaluation)
        {
            _evaluationDAO.editEvaluation(evaluation);
        }

        // DELETE ===================================================================
        // deleteEvaluation
        public void deleteEvaluation(Evaluation evaluation)
        {
            _evaluationDAO.deleteEvaluation(evaluation);
        }

    }

}
