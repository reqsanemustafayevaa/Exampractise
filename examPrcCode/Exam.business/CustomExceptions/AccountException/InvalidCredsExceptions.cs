using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.business.CustomExceptions.AccountException
{
    public class InvalidCredsExceptions:Exception
    {
        public string Propertyname { get; set; }

        public InvalidCredsExceptions()
        {

        }
        public InvalidCredsExceptions(string? message) : base(message)
        {

        }
        public InvalidCredsExceptions(string propertyname, string? message) : base(message)
        {
            Propertyname = propertyname;
        }
    }
}
