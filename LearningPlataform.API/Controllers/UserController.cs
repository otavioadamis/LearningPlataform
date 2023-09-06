using LearningPlataform.API.Authorization;
using LearningPlataform.Domain.Interfaces;
using LearningPlataform.Domain.Models;
using LearningPlataform.Domain.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlataform.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet()]
        public ActionResult<List<User>> Get()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<UserResponseDTO> GetUserById(string _id)
        {
            var user = _userService.GetUserById(_id);
            return Ok(user);
        }

        [HttpPost()]
        public ActionResult<LoginResponseModel> Signup(UserSignupDTO request)
        {
            var createdUser = _userService.Signup(request);
            return Ok(createdUser);
        }

        [HttpPost("login")]
        public ActionResult<LoginResponseModel> Login(UserLoginDTO request)
        {
            var loggedUser = _userService.Login(request);
            return Ok(loggedUser);
        }

        [HttpPut("{id}")]
        public ActionResult<UserResponseDTO> Update(string id, UserUpdateInfoDTO request)
        {
            var updatedUser = _userService.UpdateInfo(id , request);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            _userService.DeleteUser(id);
            return Ok("User has been deleted!");
        }
    }
}