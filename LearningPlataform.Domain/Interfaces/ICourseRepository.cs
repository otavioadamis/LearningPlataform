using LearningPlataform.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Domain.Interfaces
{
    public interface ICourseRepository
    {
        Course Add(Course thisCourse);
        List<Course> Get();
        Course GetById(string _id);
        void SaveChanges();
        void Delete(string _id);
    }
}
