using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Domain.Models.DTOs
{
    public class CreateCourseDTO
    {      
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Category { get; set; }
        public byte[]? CoverImage { get; set; }
    }
}
