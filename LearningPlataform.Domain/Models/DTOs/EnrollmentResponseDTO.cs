using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Domain.Models.DTOs
{
    public class EnrollmentResponseDTO
    {
        public string Id { get; set; }
        public string CourseId { get; set; }
        public string StudentId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int? CompletedLessons { get; set; }
        public string UserName { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string CourseName { get; set; } = null!;

        public EnrollmentResponseDTO CreateModel(Enrollment enrollment)
        {
            var enrollModel = new EnrollmentResponseDTO()
            {
                Id = enrollment.Id,
                CourseId = enrollment.CourseId,
                StudentId = enrollment.StudentId,
                CompletedLessons = enrollment.CompletedLessons,
                EnrollmentDate = enrollment.EnrollmentDate,
            };
            return enrollModel;
        }
    }
}
