using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Domain.Models.DTOs
{
    public class UserUpdateInfoDTO
    {
        public string NewEmail {  get; set; }
        public string NewName { get; set; }
        public byte[] NewProfilePicture { get; set; }
        public string NewBio { get; set; }

        public void UpdateFields(User user) 
        {
            user.Name = NewName;
            user.Email = NewEmail;
            user.ProfilePicture = NewProfilePicture;
            user.Bio = NewBio;
        }
    }
}
