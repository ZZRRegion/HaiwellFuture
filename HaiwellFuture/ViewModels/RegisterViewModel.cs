using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HaiwellFuture.ViewModels
{
    public class RegisterViewModel
    {
        [Required, Display(Name = "用户名"), MinLength(1)]
        public string Name { get; set; }
        [Required, Display(Name = "密码"), MinLength(1), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
