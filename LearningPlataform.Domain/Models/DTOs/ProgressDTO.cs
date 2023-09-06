using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Domain.Models.DTOs
{
    public class ProgressDTO
    {
        public string StudentName { get; set; } = null!;
        public string CourseTitle { get; set; } = null!;
        public float Progress { get; set; }
        public DateTime EnrollmentDate{ get; set; }

    }
}
