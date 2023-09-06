using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Domain.Models.DTOs
{
    public class UserSignupDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public string? Bio { get; set; }
        [Required]
        public Role Role { get; set; }
    }
}
