using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Domain.Models.DTOs
{
    public class LoginResponseModel
    {
        public string Token { get; set; }
        public UserResponseDTO User { get; set; }
    }
}
