using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CodenationContext _context;
        public CompanyService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Company> FindByAccelerationId(int accelerationId)
        {
            return _context.Candidates.Where(p => p.AccelerationId == accelerationId)
                                      .Select(p => p.Company)
                                      .Distinct()
                                      .ToList();
        }

        public Company FindById(int id)
        {
            var company = _context.Companies.FirstOrDefault(p => p.Id == id);

            return company;
        }

        public IList<Company> FindByUserId(int userId)
        {
            return _context.Candidates.Where(p => p.UserId == userId)
                                      .Select(p => p.Company)
                                      .Distinct()
                                      .ToList();
        }

        public Company Save(Company company)
        {
            if (company.Id != 0)
            {
                _context.Companies.Update(company);
            }
            else
            {
                _context.Companies.Add(company);
            }

            _context.SaveChanges();

            return company;
        }
    }
}