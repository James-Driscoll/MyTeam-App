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

        private EvaluationDAO _EvaluationDAO;
        public EvaluationService()
        {
            _EvaluationDAO = new EvaluationDAO();
        }

        // CREATE ===================================================================
        // addEvaluation
        public void addEvaluation(Evaluation evaluation)
        {
            _EvaluationDAO.addEvaluation(evaluation);
        }

        // READ =====================================================================
        // getEvaluationes
        public IList<Evaluation> getEvaluationes()
        {
            return _EvaluationDAO.getEvaluations();
        }

        // getEvaluation
        public Evaluation getEvaluation(int id)
        {
            return _EvaluationDAO.getEvaluation(id);
        }

        // UPDATE ===================================================================
        // editEvaluation
        public void editEvaluation(Evaluation evaluation)
        {
            _EvaluationDAO.editEvaluation(evaluation);
        }

        // DELETE ===================================================================
        // deleteEvaluation
        public void deleteEvaluation(Evaluation evaluation)
        {
            _EvaluationDAO.deleteEvaluation(evaluation);
        }

    }

}
