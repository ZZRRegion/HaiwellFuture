using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaiwellFuture.Services
{
    public interface IRequestIPRecord
    {
        Task Add(IpRecord ipRecord);
        Task<HashSet<IpRecord>> GetAllIp();
        Task Remove(string ip);
    }
}
