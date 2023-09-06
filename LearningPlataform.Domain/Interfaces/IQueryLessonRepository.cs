using LearningPlataform.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Domain.Interfaces
{
    public interface IQueryLessonRepository
    {
        List<Lesson> GetLessonsByCourseId(string courseId);
    }
}
