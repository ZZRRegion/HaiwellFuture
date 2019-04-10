using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaiwellFuture.Services
{
    public class ServerTimeBasket : IServerTime
    {
        public string GetTime()
        {
            return DateTime.Now.ToString();
        }
    }
}
