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
    public class QueryLessonRepository : IQueryLessonRepository
    {
        private readonly AppDbContext _context;

        public QueryLessonRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Lesson> GetLessonsByCourseId(string courseId)
        {
            return _context.Lessons
                .Where(lesson => lesson.CourseId == courseId)
                .ToList();
        }
    }
}
