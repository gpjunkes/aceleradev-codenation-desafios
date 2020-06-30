using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly CodenationContext _context;

        public SubmissionService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Submission> FindByChallengeIdAndAccelerationId(int challengeId, int accelerationId)
        {
            return _context.Submissions.Where(p => p.ChallengeId == challengeId
                                                && p.User.Candidates.Any(c => c.AccelerationId == accelerationId))
                                       .ToList();
        }

        public decimal FindHigherScoreByChallengeId(int challengeId)
        {
            var higherScore = _context.Submissions.Where(p => p.ChallengeId == challengeId)
                                                  .Max(p => p.Score);

            return higherScore;
        }

        public Submission Save(Submission submission)
        {
            var submissionExists = _context.Submissions.Find(submission.UserId, submission.ChallengeId);

            if (submissionExists != null)
            {
                submissionExists.Score = submission.Score;
                submissionExists.CreatedAt = submission.CreatedAt;
                _context.Submissions.Update(submissionExists);
            }
            else
            {
                _context.Submissions.Add(submission);
            }

            _context.SaveChanges();
            return submission;
        }
    }
}
