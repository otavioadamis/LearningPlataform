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
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _dbContext;

        public CourseRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public Course Add(Course thisCourse)
        {
            _dbContext.Courses.Add(thisCourse);
            return thisCourse;
        }

        public void Delete(string _id)
        {
            var course = _dbContext.Courses.FirstOrDefault(x => x.Id == _id);
            _dbContext.Courses.Remove(course);
        }

        public List<Course> Get()
        {
            var allCourses = _dbContext.Courses.ToList();
            return allCourses;
        }

        public Course GetById(string _id)
        {
            var course = _dbContext.Courses.FirstOrDefault(x => x.Id == _id);
            return course;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
