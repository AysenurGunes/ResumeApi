using Microsoft.AspNetCore.Mvc;
using ResumeApi.Helper;
using ResumeApi.Models;
using System.Collections.Generic;


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
        private readonly IConfiguration _configuration;
        private readonly ResumeDbContext _context;
        private ServiceResponse<User> response;
        private ServiceResponse<List<User>> responses;
        public UserController(IConfiguration configuration, ResumeDbContext context, ServiceResponse<User> serviceResponse, ServiceResponse<List<User>> serviceResponses)
        {
            response = serviceResponse;
            responses = serviceResponses;
            //for prod setting and dbconnection
            _configuration = configuration;
            _context = context;
            
        }
        [HttpGet]
        public ServiceResponse<List<User>> Get()
        {

            try
            {

                responses.Data = users;
                responses.Success = true;
                responses.actionResult = Ok();
                return responses;
            }
            catch (Exception ex)
            {
                responses.Error = ex.ToString();
                responses.actionResult = Problem();
                return responses;
            }
        }


        [HttpGet("{id}")]
        public ServiceResponse<User> Get([FromQuery] int id)
        {
           
            try
            {
                response.Data = users.Where(c => c.UserID == id).FirstOrDefault();
                if (response.Data == null)
                {
                    response.actionResult = NoContent();
                }
                else
                    response.actionResult = Ok();
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Error = ex.ToString();
                response.actionResult = Problem();
                return response;
            }
        }


        [HttpPost]
        public ServiceResponse<User> Post([FromBody] User user)
        {
           
            try
            {
                users.Add(user);
                response.Data = user;
                response.Success = true;
                response.actionResult = Ok();
                return response;
            }
            catch (Exception ex)
            {
                response.Error = ex.ToString();
                response.actionResult = Problem();
                return response;
            }
        }


        [HttpPut("{id}")]
        public ServiceResponse<User> Put(int id, [FromBody] User user)
        {
            
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
                response.actionResult = Ok();
                return response;
            }
            catch (Exception ex)
            {
                response.Error = ex.ToString();
                response.actionResult = Problem();
                return response;
            }
        }


        [HttpDelete("{id}")]
        public ServiceResponse<User> Delete(int id)
        {
            
            try
            {
                users.Remove(users.Where(c => c.UserID == id).FirstOrDefault());


                response.Success = true;
                response.actionResult = Ok();
                return response;
            }
            catch (Exception ex)
            {
                response.Error = ex.ToString();
                response.actionResult = Problem();
                return response;
            }
        }
    }
}
