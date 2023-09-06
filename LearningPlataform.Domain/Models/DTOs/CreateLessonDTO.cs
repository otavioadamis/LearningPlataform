using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Domain.Models.DTOs
{
    public class CreateLessonDTO
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
    }
}
