using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Domain.Models.DTOs
{
    public class UserResponseDTO
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public string Bio { get; set; }
        public Role Role { get; set; }

        public UserResponseDTO CreateModel(User user)
        {
            var userModel = new UserResponseDTO()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Bio = user.Bio,
                ProfilePicture = user.ProfilePicture,
                Role = user.Role
            };
            return userModel;
        }
    }
}
