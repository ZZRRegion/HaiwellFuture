using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HaiwellFuture.ViewModels
{
    public class LoginViewModel
    {
        [Required, Display(Name = "用户名"), MinLength(1)]
        public string Name { get; set; }
        [Required, Display(Name = "密码"), MinLength(1), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
