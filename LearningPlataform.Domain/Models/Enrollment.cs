using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Domain.Models
{
    public class Enrollment
    {
        [Key]
        public string Id { get; set; } = null!;

        public string CourseId { get; set; }
        public Course Course { get; set; } = null!;

        public string StudentId { get; set; }
        public User Student { get; set; } = null!;
        
        public DateTime EnrollmentDate { get; set; }
        public int? CompletedLessons { get; set; }
    }
}

// Properties: ID, Student ID, Course ID, Enrollment Date, Progress Tracking (array of completed lesson IDs).
