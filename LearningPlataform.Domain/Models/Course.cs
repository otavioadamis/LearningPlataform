using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Domain.Models
{
    public class Course
    {
        [Key]
        public string Id { get; set; } = null!;
        public required string Category { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public byte[]? CoverImage { get; set; }
        public DateTime CreatedDate { get; set; }    
                   
        // EF Core Purposes ( one to many and many to many ) 
        public string InstructorId { get; set; }
        public User? Instructor { get; set; }
        public List<User>? Students { get; set; }
        public List<Lesson>? Lessons { get; set; }
    }
}

//Properties: ID, Title, Description, Category, Cover Image, Created Date, Instructor ID.