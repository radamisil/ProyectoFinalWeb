using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdondeVamos.Model.GenericClass
{
    public class APIResponse
    {
        //public APIResponse();
        
        public int Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public bool isOk { get; }

        /*public  APIResponse Error(string message = "");
        public abstract APIResponse Error(int status, string message);
        public abstract APIResponse OK(string message = "");
        public abstract APIResponse OK(object data, string message);*/    
    }
}