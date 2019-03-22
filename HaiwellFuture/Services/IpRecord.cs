using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;

namespace HaiwellFuture.Services
{
    public class IpRecord
    {
        [BsonId]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Ip { get; set; }
        public DateTime DateTime { get; set; }
        /// <summary>
        /// 平台
        /// </summary>
        public string UserAgent { get; set; }
        /// <summary>
        /// 访问次数
        /// </summary>
        public int Count { get; set; } = 1;
    }
}
