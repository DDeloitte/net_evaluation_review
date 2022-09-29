using Evaluacion.Models;
using Microsoft.AspNetCore.Mvc;

namespace Evaluacion.Controllers

    //localhost/user/get/1
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        //Lista predeterminada de usuarios
        private static List<User> usersList = new List<User>()
        {
            new User() {UserId = 1, Name = "David", UserType = UserType.User, Email = "email1@email.com" },
            new User() {UserId = 2, Name = "Guillermo", UserType = UserType.SystemAdmin, Email = "email2@email.com" },
            new User() {UserId = 3, Name = "Daniel", UserType = UserType.SystemAdmin, Email = "email3@email.com" },
            new User() {UserId = 4, Name = "Oscar", UserType = UserType.SystemAdmin, Email = "email4@email.com" }
        };

        //Add User
        [HttpPost("add")]
        public IActionResult Add(User usuario)
        {
            var userListCount = usersList.Count(); 
            usuario.UserId = userListCount+1;
            usersList.Add(usuario);
            return Ok(usuario);
        }

        //Get User
        [HttpGet("get/{id}")]
        public IActionResult ObtenerUsuario(int id)
        {
            try
            {
                var user = usersList.First(user => user.UserId == id);
                return Ok(user);
                
            }
            catch (Exception Ex)
            {
                
                return Ok(Ex.Message);
            }

        }

        //Update User
        [HttpPatch("update")]
        public IActionResult ActualizarUsuario(User usuario)
        {
            foreach (var user in usersList)
            {
                if (user.UserId == usuario.UserId)
                {
                    user.UserType = usuario.UserType;
                    user.Name = usuario.Name;
                    user.Email = usuario.Email;
                }
            } 
            return Ok(usuario);
        }

        //Users in datababase
        [HttpGet("getCount")]
        public IActionResult GetCount()
        {
            var usersCount = usersList.Count();
            return Ok(usersCount);
        }

        //Delete User end point
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
            //First identify the user
            foreach (var user in usersList)
            {
                if (user.UserId == id)
                {
                    usersList.Remove(user);
                }
            } 

            return Ok();
            }
            catch (Exception Ex)
            {
                
                return Ok(Ex.Message);
            }

        }

    }
}
