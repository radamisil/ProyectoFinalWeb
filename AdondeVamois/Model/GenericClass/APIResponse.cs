using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdondeVamos.Model.GenericClass
{
    public class APIResponse
    {       
        public int Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public bool isOk { get; }
        /*
        public static  Error(string message = "");
        public static  Error(int status, string message);
        public static  OK(string message = "");
        public static  OK(object data, string message);
        */
    }
}