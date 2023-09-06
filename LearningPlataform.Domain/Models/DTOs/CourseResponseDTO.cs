using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Domain.Models.DTOs
{
    public class CourseResponseDTO
    {
        public string? Id { get; set; }
        public string Category { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string InstructorId { get; set; }

        public CourseResponseDTO CreateModel(Course course)
        {
            var courseModel = new CourseResponseDTO()
            {
                Id = course.Id,
                Category = course.Category,
                Title = course.Title,
                Description = course.Description,
                InstructorId = course.InstructorId,
            };
            return courseModel;
        }
    }
}
