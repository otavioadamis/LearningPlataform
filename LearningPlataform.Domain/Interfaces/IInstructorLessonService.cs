using LearningPlataform.Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Domain.Interfaces
{
    public interface IInstructorLessonService
    {
        LessonResponseDTO CreateLesson(string instructorId, string courseId, CreateLessonDTO thisLesson);
    }
}
