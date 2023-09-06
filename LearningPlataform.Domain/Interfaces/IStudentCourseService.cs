using LearningPlataform.Domain.Models;
using LearningPlataform.Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Domain.Interfaces
{
    public interface IStudentCourseService
    {
        EnrollmentResponseDTO Enroll(string userId, string courseId);
        EnrollmentResponseDTO CompleteLesson(string enrollmentId);
        ProgressDTO GetProgress(string enrollmentId);
    }
}
