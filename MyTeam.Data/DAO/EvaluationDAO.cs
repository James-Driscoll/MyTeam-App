using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTeam.Data.IDAO;

namespace MyTeam.Data.DAO
{

    public class EvaluationDAO : IEvaluationDAO
    {

        private MyTeamDataEntities _context;

        public EvaluationDAO()
        {
            _context = new MyTeamDataEntities();
        }

        // CREATE ====================================================================
        // addEvaluation
        public void addEvaluation(Evaluation evaluation)
        {
            _context.Evaluations.Add(evaluation);
            _context.SaveChanges();
        }

        // READ ======================================================================
        // getEvaluations
        public IList<Evaluation> getEvaluations(int id)
        {
            IQueryable<Evaluation> _evaluations;
            _evaluations = from evaluation
                           in _context.Evaluations
                           where evaluation.FK_Task == id
                           select evaluation;
            return _evaluations.ToList<Evaluation>();
        }

        // getEvaluation
        public Evaluation getEvaluation(int id)
        {
            IQueryable<Evaluation> _evaluation;
            _evaluation = from evaluation
                          in _context.Evaluations
                          where evaluation.Id == id
                          select evaluation;
            return _evaluation.ToList<Evaluation>().First();
        }

        // getCompletedEvaluations
        public IList<Evaluation> getCompletedEvaluations(string id)
        {
            IQueryable<Evaluation> _evaluations;
            _evaluations = from evaluation in _context.Evaluations
                           join task in _context.Tasks on evaluation.FK_Task equals task.Id
                           where task.Status == "Finished"
                           where task.FK_AssignedTo == id
                           select evaluation;
            return _evaluations.ToList<Evaluation>();
        }

        // UPDATE ====================================================================
        // editEvaluation
        public void editEvaluation(Evaluation evaluation)
        {
            Evaluation record = (from rec
                                 in _context.Evaluations
                                 where rec.Id == evaluation.Id
                                 select rec).ToList<Evaluation>().First();
            record.FK_Assessor = evaluation.FK_Assessor;
            record.FK_Task = evaluation.FK_Task;
            record.Mark = evaluation.Mark;
            record.Comments = evaluation.Comments;
            _context.SaveChanges();
        }

        // DELETE ====================================================================
        // deleteEvaluation
        public void deleteEvaluation(Evaluation evaluation)
        {
            _context.Evaluations.Remove(evaluation);
            _context.SaveChanges();
        }

    }

}
