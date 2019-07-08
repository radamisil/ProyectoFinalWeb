using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdondeVamos.Model.Exception
{
    public class ApertureValidationException : SystemException
    {
        public ApertureValidationException(string message) : base("ApertureValidationException: " + message)
        {
        }
    }
}