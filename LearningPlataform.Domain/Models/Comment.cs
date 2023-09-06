using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Domain.Models
{
    public class Comment
    {
        [Key]
        public string Id { get; set; } = null!;

        // A comment from one user
        public string UserId { get; set; } = null!;

        // A comment in a lesson
        public string LessonId { get; set; } = null!;

        // Comment properties
        public required string Text { get; set; }
        public DateTime PostedAt { get; set; }
    }
}

// Properties: ID, User ID, Course ID (optional), Lesson ID (optional), Content, Creation Date.