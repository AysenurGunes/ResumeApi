using Microsoft.AspNetCore.Mvc;
using ResumeApi.Helper;
using ResumeApi.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResumeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public List<User> users = new List<User>()
        {
            new User()
            {
                UserID= 1,
                Email="abc@gmail.com",
                FirstInformation= "ilk izlenim yazisi",
                Name="Aysenur",
                Surname="Gunes",
                Password="123"
            } ,
            new User()
            {
                UserID= 2,
                Email="abc@abc.com",
                FirstInformation= "Abc yazilim firmasi",
                Name="Abc",
                Surname="Company",
                Password="12"
            } ,
        };

        [HttpGet]
        public ServiceResponse<List<User>> Get()
        {
            ServiceResponse<List<User>> response = new ServiceResponse<List<User>>();
            try
            {

                response.Data = users;
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Error = ex.ToString();
                return response;
            }
        }


        [HttpGet]
        public ServiceResponse<User> Get([FromQuery] int id)
        {
            ServiceResponse<User> response = new ServiceResponse<User>();
            try
            {
                response.Data = users.Where(c => c.UserID == id).FirstOrDefault();
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Error = ex.ToString();
                return response;
            }
        }


        [HttpPost]
        public ServiceResponse<User> Post([FromBody] User user)
        {
            ServiceResponse<User> response = new ServiceResponse<User>();
            try
            {
                users.Add(user);
                response.Data = user;
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Error = ex.ToString();
                return response;
            }
        }


        [HttpPut("{id}")]
        public ServiceResponse<User> Put(int id, [FromBody] User user)
        {
            ServiceResponse<User> response = new ServiceResponse<User>();
            try
            {
                User user1 = users.Where(c => c.UserID == id).FirstOrDefault();
                user1.Email = user.Email;
                user1.Surname = user.Surname;
                user1.Name = user.Name;
                user1.FirstInformation = user.FirstInformation;
                user1.Password = user.Password;

                response.Data = user;
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Error = ex.ToString();
                return response;
            }
        }


        [HttpDelete("{id}")]
        public ServiceResponse<ActionResult> Delete(int id)
        {
            ServiceResponse<ActionResult> response = new ServiceResponse<ActionResult>();
            try
            {
                users.RemoveAt(c => c.UserID == id);

                response.Data = Ok();
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Error = ex.ToString();
                return response;
            }
        }
    }
}
