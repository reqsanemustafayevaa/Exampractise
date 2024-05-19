using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.business.CustomExceptions.CommonExceptions
{
    public class EntityNotfoundException: Exception
    {
        public  string Propertyname {  get; set; }

        public EntityNotfoundException()
        {
            
        }
        public EntityNotfoundException(string? message):base(message) 
        {
            
        }
        public EntityNotfoundException(string propertyname,string? message):base(message)
        {
            Propertyname= propertyname;
        }
    }
}
