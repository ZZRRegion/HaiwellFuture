using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaiwellFuture.Services
{
    public interface IRequestIPRecord
    {
        Task Add(string ip);
        Task<HashSet<string>> GetAllIp();
    }
}
