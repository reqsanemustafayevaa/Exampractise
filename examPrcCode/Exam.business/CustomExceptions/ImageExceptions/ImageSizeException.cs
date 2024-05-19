using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.business.CustomExceptions.ImageExceptions
{
    public class ImageSizeException:Exception
    {
        public string Propertyname { get; set; }

        public ImageSizeException()
        {

        }
        public ImageSizeException(string? message) : base(message)
        {

        }
        public ImageSizeException(string propertyname, string? message) : base(message)
        {
            Propertyname = propertyname;
        }
    }
}
