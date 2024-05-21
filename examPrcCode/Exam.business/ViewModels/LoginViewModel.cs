using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Exam.business.ViewModels
{
    public class LoginViewModel
    {
        [StringLength(maximumLength:60,MinimumLength =9)]
        [Required] 
        public string UserName {  get; set; }
        [StringLength(maximumLength: 20, MinimumLength = 8)]
        [Required]
        public string Password { get; set; }
    }
}
