using LearningPlataform.API.Authorization;
using LearningPlataform.Domain.Interfaces;
using LearningPlataform.Domain.Models;
using LearningPlataform.Domain.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlataform.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class LessonController : ControllerBase
    {
        private readonly IInstructorLessonService _instructorLessonService;
        private readonly IUserService _userService;
        private readonly IStudentCourseService _studentCourseService;

        public LessonController(IInstructorLessonService instructorLessonService, IUserService userService, IStudentCourseService studentCourseService)
        {
            _instructorLessonService = instructorLessonService;
            _userService = userService;
            _studentCourseService = studentCourseService;
        }

        [CustomAuthorize(Role.Instructor)]
        [HttpPost("addlesson/{courseId}")]
        public LessonResponseDTO CreateLesson(CreateLessonDTO thisLesson, string courseId)
        {
            var user = HttpContext.Items["User"] as User;
            var createdLesson = _instructorLessonService.CreateLesson(user.Id, courseId, thisLesson);
            return createdLesson;
        }

        [CustomAuthorize(Role.Student)]
        [HttpPost("completelesson/{enrollmentId}")]
        public EnrollmentResponseDTO CompleteLesson(string enrollmentId)
        {
            var enrollment = _studentCourseService.CompleteLesson(enrollmentId);
            return enrollment;
        }

        [CustomAuthorize(Role.Student)]
        [HttpPost("progress/{enrollmentId}")]
        public ProgressDTO GetProgress(string enrollmentId)
        {
            var progress = _studentCourseService.GetProgress(enrollmentId);
            return progress;
        }
    }
}
