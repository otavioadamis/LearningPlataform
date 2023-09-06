using LearningPlataform.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Domain.Interfaces
{
    public interface IEnrollmentRepository
    {
        void SaveChanges();
        Enrollment Add(Enrollment thisEnrollment);
        List<Enrollment> Get();
        Enrollment GetById(string _id);
        void Delete(string _id);
    }
}
