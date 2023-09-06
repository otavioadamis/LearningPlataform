using System.ComponentModel.DataAnnotations;

namespace LearningPlataform.Domain.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; } = null!;
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public string? Bio { get; set; }
        public Role Role { get; set; }


        public List<Course>? CreatedCourses { get; set; } //EF Core purposes ( one to many )
        public List<Course>? EnrolledCourses { get; set; } // EF Core purposes ( many to many )
    }
}

//ID, Username, Email, Password, Profile Picture, Bio, Role.