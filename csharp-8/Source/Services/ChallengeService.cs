using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class ChallengeService : IChallengeService
    {
        private readonly CodenationContext _context;
        public ChallengeService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Models.Challenge> FindByAccelerationIdAndUserId(int accelerationId, int userId)
        {
            var query = from challenges in _context.Challenges
                        join accelerations in _context.Accelerations on challenges.Id equals accelerations.ChallengeId
                        join candidates in _context.Candidates on accelerations.Id equals candidates.AccelerationId
                       where accelerations.Id == accelerationId 
                          && candidates.UserId == userId                           
                        select challenges;

            return query.Distinct().ToList();
        }

        public Models.Challenge Save(Models.Challenge challenge)
        {
            if (challenge.Id != 0)
            {
                _context.Challenges.Update(challenge);
            }
            else
            {
                _context.Challenges.Add(challenge);
            }

            _context.SaveChanges();

            return challenge;
        }        
    }
}