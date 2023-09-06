using LearningPlataform.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Domain.Interfaces
{
    public interface IUserRepository
    {
        User Add(User thisUser);
        List<User> Get();
        User GetById(string _id);
        User GetByEmail(string _email);
        void SaveChanges();
        void Delete(string _id);

    }
}
