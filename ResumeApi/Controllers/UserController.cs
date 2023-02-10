﻿using Microsoft.AspNetCore.Mvc;
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
      
        public UserController(IConfiguration configuration, ResumeDbContext context,ServiceResponse<User> serviceResponse)
        {
            response = serviceResponse;
            
            //for prod setting and dbconnection
            _configuration = configuration;
            _context = context;

        }
        [HttpGet("GetAll")]
        public ServiceResponse<List<User>> GetAll()
        {
            ServiceResponse<List<User>> responses2 = new ServiceResponse<List<User>>();//it is bug i need search
            try
            {

                responses2.Data = users;
                responses2.Success = true;
                responses2.statusCode = StatusCodes.Status200OK;
                return responses2;
            }
            catch (Exception ex)
            {
                responses2.Error = ex.ToString();
                responses2.statusCode = StatusCodes.Status400BadRequest; ;
                return responses2;
            }
        }


        [HttpGet("GetByID")]
        public ServiceResponse<User> Get([FromQuery] int id)
        {
             //ServiceResponse<User> response=new ServiceResponse<User>();
            try
            {
                response.Data = users.Where(c => c.UserID == id).FirstOrDefault();
                if (response.Data == null)
                {
                    response.statusCode =StatusCodes.Status204NoContent;
                }
                else
                    response.statusCode = StatusCodes.Status200OK;
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Error = ex.ToString();
                response.statusCode = StatusCodes.Status400BadRequest;
                return response;
            }
        }
        [HttpGet("GetOrderByName")]
        public ServiceResponse<List<User>> Get()
        {
            ServiceResponse<List<User>> responses2 = new ServiceResponse<List<User>>();//it is bug i need search
            try
            {
                responses2.Data = users.OrderBy(c => c.Name).ToList();
                if (responses2.Data == null)
                {
                    responses2.statusCode = StatusCodes.Status204NoContent;
                }
                else
                    responses2.statusCode = StatusCodes.Status200OK;
                responses2.Success = true;
                return responses2;
            }
            catch (Exception ex)
            {
                responses2.Error = ex.ToString();
                responses2.statusCode = StatusCodes.Status400BadRequest;
                return responses2;
            }
        }
        [HttpGet("GetSearchByName")]
        public ServiceResponse<List<User>> Get([FromQuery] string name)
        {
            ServiceResponse<List<User>> responses2 = new ServiceResponse<List<User>>();//it is bug i need search
            try
            {
                responses2.Data = users.Where(c => c.Name.Contains(name)).ToList();
                if (responses2.Data == null)
                {
                    responses2.statusCode = StatusCodes.Status204NoContent;
                }
                else
                    responses2.statusCode = StatusCodes.Status200OK;
                responses2.Success = true;
                return responses2;
            }
            catch (Exception ex)
            {
                responses2.Error = ex.ToString();
                responses2.statusCode = StatusCodes.Status400BadRequest;
                return responses2;
            }
        }
        [HttpPost]
        public ServiceResponse<User> Post([FromBody] User user)
        {
           // ServiceResponse<User> response = new ServiceResponse<User>();
            try
            {
                users.Add(user);
                response.Data = user;
                response.Success = true;
                response.statusCode = StatusCodes.Status200OK;
                return response;
            }
            catch (Exception ex)
            {
                response.Error = ex.ToString();
                response.statusCode = StatusCodes.Status400BadRequest;
                return response;
            }
        }


        [HttpPut("{id}")]
        public ServiceResponse<User> Put(int id, [FromBody] User user)
        {
           // ServiceResponse<User> response = new ServiceResponse<User>();
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
                response.statusCode = StatusCodes.Status200OK;
                return response;
            }
            catch (Exception ex)
            {
                response.Error = ex.ToString();
                response.statusCode = StatusCodes.Status400BadRequest;
                return response;
            }
        }


        [HttpDelete("{id}")]
        public ServiceResponse<User> Delete(int id)
        {
           // ServiceResponse<User> response = new ServiceResponse<User>();
            try
            {
                users.Remove(users.Where(c => c.UserID == id).FirstOrDefault());


                response.Success = true;
                response.statusCode = StatusCodes.Status200OK;
                return response;
            }
            catch (Exception ex)
            {
                response.Error = ex.ToString();
                response.statusCode = StatusCodes.Status400BadRequest;
                return response;
            }
        }
    }
}
