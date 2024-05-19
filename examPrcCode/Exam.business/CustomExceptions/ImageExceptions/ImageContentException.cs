﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.business.CustomExceptions.ImageExceptions
{
    public class ImageContentException:Exception
    {
        public string Propertyname { get; set; }

        public ImageContentException()
        {

        }
        public ImageContentException(string? message) : base(message)
        {

        }
        public ImageContentException(string propertyname, string? message) : base(message)
        {
            Propertyname = propertyname;
        }
    }
}
