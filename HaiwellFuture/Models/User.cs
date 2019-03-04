using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HaiwellFuture.Models
{

    public class User:BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime DateTime { get; set; }
    }
}
