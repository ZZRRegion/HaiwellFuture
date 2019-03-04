using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HaiwellFuture.Models
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
