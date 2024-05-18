using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Exam.Core.Models
{
    public class Doctor:BaseEntity
    {
        [Required]
        [StringLength(65)]

        public string Name { get; set; }
        [Required]
        [StringLength(50)]

        public string Position { get; set; }
        [Required]
        [StringLength(100)]

        public string TwitterUrl { get; set; }
        [Required]
        [StringLength(100)]

        public string InstaUrl { get; set; }
        [Required]
        [StringLength(100)]


        public string Fburl { get; set; }
        [Required]
        [StringLength(100)]


        public string LNKUrl { get; set; }
 
        [StringLength(100)]


        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
