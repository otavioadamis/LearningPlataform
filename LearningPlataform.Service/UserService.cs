using LearningPlataform.Domain.Interfaces;
using LearningPlataform.Domain.Models;
using LearningPlataform.Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthorizationService _authorizationService;

        public UserService(IUserRepository userRepository, IAuthorizationService authorizationService)
        {
            _userRepository = userRepository;
            _authorizationService = authorizationService;
        }

        public User GetById(string id)
        {
            var user = _userRepository.GetById(id) ?? throw new ArgumentException("Not found");
            return user;
        }

        public UserResponseDTO GetUserById(string _id)
        {
            var user = _userRepository.GetById(_id);
            
            var userModel = new UserResponseDTO();
            userModel = userModel.CreateModel(user);
            
            return userModel;
        }

        // Create
        public LoginResponseModel Signup(UserSignupDTO thisUser)
        {
            var checkEmail = _userRepository.GetByEmail(thisUser.Email);
            if (checkEmail != null)
            {
                throw new ArgumentException("Sorry! This email has already been used!");
            }

            thisUser.Password = BCrypt.Net.BCrypt.HashPassword(thisUser.Password);

            var newUser = new User()
            {
                Email = thisUser.Email,
                Name = thisUser.Name,
                Password = thisUser.Password,
                Role = thisUser.Role,
                ProfilePicture = thisUser.ProfilePicture,
                Bio = thisUser.Bio
            };

            _userRepository.Add(newUser);
            _userRepository.SaveChanges();
            
            string token = _authorizationService.CreateToken(newUser);

            var userModel = new UserResponseDTO();
            userModel = userModel.CreateModel(newUser);

            var res = new LoginResponseModel
            {
                Token = token,
                User = userModel
            }; 

            return res;
        }

        public LoginResponseModel Login(UserLoginDTO thisUser)
        {
            var user = _userRepository.GetByEmail(thisUser.Email) ?? throw new ArgumentException("User Not found");

            bool isPasswordMatch = BCrypt.Net.BCrypt.Verify(thisUser.Password, user.Password);
            if (!isPasswordMatch) { throw new ArgumentException("Invalid credentials!"); }

            string token = _authorizationService.CreateToken(user);

            var userModel = new UserResponseDTO();
            userModel = userModel.CreateModel(user);

            var res = new LoginResponseModel
            {
                Token = token,
                User = userModel
            };
            
            return res;
        }

        // Read
        public List<User> GetAllUsers()
        {
            var users = _userRepository.Get() ?? throw new ArgumentException("Theres nobody here!");
            return users;
        }

        // Update
        public UserResponseDTO UpdateInfo(string _id, UserUpdateInfoDTO updatedUser)
        {
            var user = _userRepository.GetById(_id) ?? throw new ArgumentException("User not found!");

            updatedUser.UpdateFields(user);    
            _userRepository.SaveChanges();

            var userModel = new UserResponseDTO();
            userModel = userModel.CreateModel(user);
            
            return userModel;
        }

        // Delete
        public void DeleteUser(string _id)
        {
            _userRepository.Delete(_id); 
            _userRepository.SaveChanges();
        }

    }
}
