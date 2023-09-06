using LearningPlataform.Domain.Models;
using LearningPlataform.Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Domain.Interfaces
{
    public interface IUserService
    {
        User GetById(string id);
        LoginResponseModel Signup(UserSignupDTO thisUser);
        LoginResponseModel Login(UserLoginDTO thisUser);
        UserResponseDTO GetUserById(string _id);
        List<User> GetAllUsers();
        UserResponseDTO UpdateInfo(string _id, UserUpdateInfoDTO updatedUser);
        void DeleteUser(string _id);
    }
}
