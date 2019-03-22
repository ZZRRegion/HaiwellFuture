using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaiwellFuture.ViewModels
{
    public class IpViewModel
    {
        public HashSet<Services.IpRecord> HashIp { get; set; }
        public string xAxis { get; set; }
        public string series { get; set; }
    }
}
