using LearningPlataform.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Domain.Interfaces
{
    public interface ILessonRepository
    {
        void SaveChanges();
        Lesson Add(Lesson thisLesson);
        List<Lesson> Get();
        Lesson GetById(string _id);
        void Delete(string _id);
    }
}
