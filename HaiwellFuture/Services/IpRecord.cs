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
    }
}
