using LearningPlataform.Domain.Interfaces;
using LearningPlataform.Domain.Models;
using LearningPlataform.Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Service
{
    public class InstructorCourseService : IInstructorCourseService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICourseRepository _courseRepository;

        public InstructorCourseService(IUserRepository userRepository, ICourseRepository coourseRepository)
        {
            _userRepository = userRepository;
            _courseRepository = coourseRepository;
        }

 
        public CourseResponseDTO CreateCourse(string _id, CreateCourseDTO thisCourse)
        {
            var instructorId = _userRepository.GetById(_id);
            if (instructorId == null) { throw new ArgumentException("An error ocurred!"); }

            var newCourse = new Course()
            {
                Title = thisCourse.Title,
                Category = thisCourse.Category,
                Description = thisCourse.Description,
                CoverImage = thisCourse.CoverImage,
                CreatedDate = DateTime.UtcNow,
                InstructorId = _id,
            };

            _courseRepository.Add(newCourse);
            _courseRepository.SaveChanges();

            var courseModel = new CourseResponseDTO();
            courseModel = courseModel.CreateModel(newCourse);

            return courseModel;
        }
    }
}
