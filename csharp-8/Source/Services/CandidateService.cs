using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly CodenationContext _context;

        public CandidateService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Candidate> FindByAccelerationId(int accelerationId)
        {
            var candidates = _context.Candidates.Where(p => p.AccelerationId == accelerationId)
                                                .ToList();

            return candidates;
        }

        public IList<Candidate> FindByCompanyId(int companyId)
        {
            var candidates = _context.Candidates.Where(p => p.CompanyId == companyId)
                                                .ToList();

            return candidates;
        }

        public Candidate FindById(int userId, int accelerationId, int companyId)
        {
            var candidate = _context.Candidates.FirstOrDefault(p => p.UserId == userId
                                                                 && p.AccelerationId == accelerationId
                                                                 && p.CompanyId == companyId);

            return candidate;
        }

        public Candidate Save(Candidate candidate)
        {
            var candidateExists = _context.Candidates.Find(candidate.UserId, candidate.AccelerationId, candidate.CompanyId);

            if (candidateExists != null)
            {
                candidateExists.Status = candidate.Status;
                candidateExists.CreatedAt = candidate.CreatedAt;
                _context.Candidates.Update(candidateExists); 
            }
            else
            {
                _context.Candidates.Add(candidate);
            }

            _context.SaveChanges();
            return candidate;
        }
    }
}
