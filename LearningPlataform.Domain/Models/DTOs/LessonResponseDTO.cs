using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Domain.Models.DTOs
{
    public class LessonResponseDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public LessonResponseDTO CreateModel(Lesson lesson)
        {
            var lessonModel = new LessonResponseDTO()
            {
                Id = lesson.Id,
                Title = lesson.Title,
                Description = lesson.Description,
            };
            return lessonModel;
        }
    }
}
