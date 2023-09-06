using LearningPlataform.Domain.Interfaces;
using LearningPlataform.Domain.Models;
using LearningPlataform.Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Service
{
    public class StudentCourseService : IStudentCourseService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;
        
        private readonly IQueryLessonRepository _queryLessonRepository;

        public StudentCourseService(IUserRepository userRepository, ICourseRepository coourseRepository , IEnrollmentRepository enrollmentRepository, IQueryLessonRepository queryLessonRepository)
        {
            _userRepository = userRepository;
            _courseRepository = coourseRepository;
            _enrollmentRepository = enrollmentRepository;
            
            _queryLessonRepository = queryLessonRepository;
        }

        public EnrollmentResponseDTO Enroll(string userId, string courseId)
        {
            var user = _userRepository.GetById(userId) ?? throw new ArgumentException("User Not found");
            var course = _courseRepository.GetById(courseId) ?? throw new ArgumentException("Course Not found");

            var newEnroll = new Enrollment
            {
                CourseId = courseId,
                StudentId = userId,
                EnrollmentDate = DateTime.UtcNow,
                CompletedLessons = 0
            };

            _enrollmentRepository.Add(newEnroll);
            _enrollmentRepository.SaveChanges();

            var enrollModel = new EnrollmentResponseDTO();
            enrollModel.CreateModel(newEnroll);

            enrollModel.CourseName = course.Title;
            enrollModel.UserName = user.Name;
            enrollModel.UserEmail = user.Email;
            
            return enrollModel;
        }

        public EnrollmentResponseDTO CompleteLesson(string enrollmentId)
        {
            var enrollment = _enrollmentRepository.GetById(enrollmentId) ?? throw new ArgumentException("Error finding your enrollment");
            enrollment.CompletedLessons++;
            _enrollmentRepository.SaveChanges();

            var enrollModel = new EnrollmentResponseDTO();
            enrollModel.CreateModel(enrollment);

            return enrollModel;
        }

        // TODO Adjusts on this
        public ProgressDTO GetProgress(string enrollmentId)
        {
            var enrollment = _enrollmentRepository.GetById(enrollmentId) ?? throw new ArgumentException("Error finding your enrollment");
            var allLessons = _queryLessonRepository.GetLessonsByCourseId(enrollment.CourseId);
            
            float progress = 0.0f;
            if (enrollment.CompletedLessons.HasValue && allLessons.Count > 0)
            {
                progress = (float)(enrollment.CompletedLessons.Value * 100) / allLessons.Count;
            }

            var student = _userRepository.GetById(enrollment.StudentId);
            var course = _courseRepository.GetById(enrollment.CourseId);

            var progressModel = new ProgressDTO
            {
                Progress = progress,
                EnrollmentDate = enrollment.EnrollmentDate,
                StudentName = student.Name,
                CourseTitle = course.Title
            };

            return progressModel;
        }
    }
}
