using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaiwellFuture.Services
{
    public class RequestIpRecordServices : IRequestIPRecord
    {
        private LiteDB.LiteCollection<IpRecord> lc;
        public RequestIpRecordServices()
        {
            LiteDB.LiteDatabase ldb = new LiteDB.LiteDatabase("ip.db");
            this.lc = ldb.GetCollection<IpRecord>();
        }
        public async Task Add(string ip)
        {
            IpRecord ipRecord = this.lc.FindOne(item => item.Ip == ip);
            if(ipRecord == null)
            {
                ipRecord = new IpRecord();
                ipRecord.Ip = ip;
            }
            ipRecord.DateTime = DateTime.Now;
            this.lc.Upsert(ipRecord);
            await Task.CompletedTask;
        }

        public async Task<HashSet<string>> GetAllIp()
        {
            return await Task.FromResult(this.lc.FindAll().Select(item => item.Ip).ToHashSet());

        }
    }
}
