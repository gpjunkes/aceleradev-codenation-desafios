using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class AccelerationService : IAccelerationService
    {
        private readonly CodenationContext _context;

        public AccelerationService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Acceleration> FindByCompanyId(int companyId)
        {
            var query = from accelerations in _context.Accelerations
                        join candidates in _context.Candidates on accelerations.Id equals candidates.AccelerationId
                       where candidates.CompanyId == companyId
                      select accelerations;

            return query.Distinct().ToList();
        }

        public Acceleration FindById(int id)
        {
            var acceleration = _context.Accelerations.FirstOrDefault(p => p.Id == id);

            return acceleration;
        }

        public Acceleration Save(Acceleration acceleration)
        {
            if (acceleration.Id != 0)
            {
                _context.Accelerations.Update(acceleration);
            }
            else
            {
                _context.Accelerations.Add(acceleration);
            }

            _context.SaveChanges();
            return acceleration;
        }
    }
}
