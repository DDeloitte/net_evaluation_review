using Evaluacion.Models;
using Microsoft.AspNetCore.Mvc;

namespace Evaluacion.Controllers

    //localhost/user/get/1
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private static List<User> usersList = new List<User>();
        
        [HttpPost("add")]
        public IActionResult Add(User usuario)
        {
            var userListCount = usersList.Count(); 
            usuario.UserId = userListCount+1;
            usersList.Add(usuario);
            return Ok(usuario);
        }

        [HttpGet("get/{id}")]
        public IActionResult ObtenerUsuario(int id)
        {
            var user = usersList.First(user => user.UserId == id);
            return Ok(user);
        }

        [HttpPatch("update")]
        public IActionResult ObtenerUsuario(User usuario)
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

        [HttpGet("getCount")]
        public IActionResult GetCount()
        {
            var usersCount = usersList.Count();
            return Ok(usersCount);
        }

    }
}
