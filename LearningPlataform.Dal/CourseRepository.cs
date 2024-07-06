using LearningPlataform.Dal.Data;
using LearningPlataform.Domain.Interfaces;
using LearningPlataform.Domain.Models;
using LearningPlataform.Domain.Models.DTOs;
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

        public List<CourseResponseDTO> GetAll()
        {
            var allCourses = (from course in _dbContext.Courses
                              select new CourseResponseDTO
                              {
                                  Id = course.Id,
                                  Category = course.Category,
                                  Description = course.Description,
                                  InstructorId = course.InstructorId,
                                  Title = course.Title,
                              }).ToList();
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
