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
    public class LessonRepository : ILessonRepository
    {
        private readonly AppDbContext _dbContext;

        public LessonRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        // Create
        public Lesson Add(Lesson thisLesson)
        {
            _dbContext.Lessons.Add(thisLesson);
            return thisLesson;
        }

        // Read TODO -> return all lessons from a especified course
        public List<Lesson> Get()
        {
            var allLessons = _dbContext.Lessons.ToList();
            return allLessons;
        }

        public Lesson GetById(string _id)
        {
            var lesson = _dbContext.Lessons.FirstOrDefault(x => x.Id == _id);
            return lesson;
        }

        // Delete
        public void Delete(string _id)
        {
            var lesson = _dbContext.Lessons.FirstOrDefault(x => x.Id == _id);
            _dbContext.Lessons.Remove(lesson);
        }
    }
}
