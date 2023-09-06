using LearningPlataform.Dal.Data;
using LearningPlataform.Domain.Interfaces;
using LearningPlataform.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Dal
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        
        // Save changes (?)
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        // Create
        public User Add(User thisUser)
        {
            _dbContext.Users.Add(thisUser);
            return thisUser;
        }

        // Read
        public List<User> Get()
        {
            var allUsers = _dbContext.Users.ToList();
             return allUsers;
        }

        public User GetById(string _id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == _id);
            return user;
        }
        public User GetByEmail(string email)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Email == email);
            return user;
        }

        // Delete
        public void Delete(string _id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == _id);
            _dbContext.Users.Remove(user);
        }
    }
}
