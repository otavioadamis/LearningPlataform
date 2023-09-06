using LearningPlataform.Domain.Interfaces;
using LearningPlataform.Domain.Models.DTOs;
using LearningPlataform.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Service
{
    public class InstructorLessonService : IInstructorLessonService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILessonRepository _lessonRepository;

        public InstructorLessonService(IUserRepository userRepository, ILessonRepository lessonRepository)
        {
            _userRepository = userRepository;
            _lessonRepository = lessonRepository;
        }

        public LessonResponseDTO CreateLesson(string instructorId, string courseId, CreateLessonDTO thisLesson)
        {
            var instructor = _userRepository.GetById(instructorId);
            if (instructor == null) { throw new ArgumentException("An error ocurred!"); }

            var newLesson = new Lesson()
            {
                Title = thisLesson.Title,
                Description = thisLesson.Description,
                CourseId = courseId,
            };

            _lessonRepository.Add(newLesson);
            _lessonRepository.SaveChanges();

            var lessonModel = new LessonResponseDTO();
            lessonModel = lessonModel.CreateModel(newLesson);

            return lessonModel;
        }
    }
}
