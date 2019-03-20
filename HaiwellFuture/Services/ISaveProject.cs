using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HaiwellFuture.Services
{
    public interface ISaveProject
    {
        Task Save(FormCollection form);
    }
}
