using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class UserService : IUserService
    {
        private readonly CodenationContext _context;
        public UserService(CodenationContext context)
        {
            _context = context;
        }

        public IList<User> FindByAccelerationName(string name)
        {
            return (_context.Candidates.Where(p => p.Acceleration.Name == name)
                                       .Select(p => p.User).ToList());
        }

        public IList<User> FindByCompanyId(int companyId)
        {
            var query = from users in _context.Users
                        join candidates in _context.Candidates on users.Id equals candidates.UserId
                       where candidates.CompanyId == companyId
                      select users;

            return query.Distinct().ToList();
        }

        public User FindById(int id)
        {
            var user = _context.Users.FirstOrDefault(p => p.Id == id);

            return user;
        }

        public User Save(User user)
        {
            if (user.Id != 0) { 
                _context.Users.Update(user);
            }
            else
            {
                _context.Users.Add(user);
            }

            _context.SaveChanges();

            return user;
        }
    }
}
