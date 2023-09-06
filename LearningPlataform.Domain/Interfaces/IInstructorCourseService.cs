using LearningPlataform.Domain.Models;
using LearningPlataform.Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Domain.Interfaces
{
    public interface IInstructorCourseService
    {
        CourseResponseDTO CreateCourse(string _id, CreateCourseDTO thisCourse);
    }
}
