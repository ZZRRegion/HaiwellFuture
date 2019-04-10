using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaiwellFuture.Services
{
    public interface IServerTime
    {
        /// <summary>
        /// 获取服务端时间
        /// </summary>
        /// <returns></returns>
        string GetTime();
    }
}
