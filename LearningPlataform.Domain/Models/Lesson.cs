using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Domain.Models
{
    public class Lesson
    {
        [Key]
        public string Id { get; set; } = null!;
        public required string Title { get; set; }
        public required string Description { get; set; }


        // EF Core Purposes
        public string CourseId { get; set; }  
        public Course Course { get; set; } = null!;
    }
}

//Properties: ID, Title,  Todo -> Content (text, video, etc.), Order, Course ID.