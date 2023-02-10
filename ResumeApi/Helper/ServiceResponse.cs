﻿using Microsoft.AspNetCore.Mvc;

namespace ResumeApi.Helper
{
    public class ServiceResponse<TEntity>
    {
        public ServiceResponse()
        {
            
        }
        public ServiceResponse(TEntity data)
        {
            Data = data;
        }

        public ServiceResponse(string error)
        {
            Error = error;
            Success = false;
        }

        public TEntity? Data { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
        public int statusCode { get; set; }
    }
}
