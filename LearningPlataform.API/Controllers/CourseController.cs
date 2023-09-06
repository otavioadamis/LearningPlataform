using LearningPlataform.API.Authorization;
using LearningPlataform.Domain.Interfaces;
using LearningPlataform.Domain.Models;
using LearningPlataform.Domain.Models.DTOs;
using LearningPlataform.Service;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlataform.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly IInstructorCourseService _InstructorCourseService;
        private readonly IStudentCourseService _StudentCourseService;

        public CourseController(IInstructorCourseService instructorCourseService, IStudentCourseService studentCourseService)
        {
            _InstructorCourseService = instructorCourseService;
            _StudentCourseService = studentCourseService;
        }

        [CustomAuthorize(Role.Instructor)]
        [HttpPost("create")]
        public ActionResult<CourseResponseDTO> Create(CreateCourseDTO thisCourse) 
        {
            var user = HttpContext.Items["User"] as User;
            var createdCourse = _InstructorCourseService.CreateCourse(user.Id, thisCourse);
            return Ok(createdCourse);
        }

        [CustomAuthorize(Role.Student)]
        [HttpPost("enroll/{courseId}")]
        public ActionResult<EnrollmentResponseDTO> Enroll(string courseId)
        {
            var user = HttpContext.Items["User"] as User;
            var enrollment = _StudentCourseService.Enroll(user.Id, courseId);
            return Ok(enrollment);
        }
    }
}
