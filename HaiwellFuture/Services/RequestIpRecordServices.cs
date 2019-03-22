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
        public async Task Add(IpRecord ip)
        {
            IpRecord find = this.lc.FindOne(item => item.Ip == ip.Ip);
            if(find != null)
            {
                find.UserAgent = ip.UserAgent;
                find.DateTime = DateTime.Now;
                find.Count = find.Count + 1;
                this.lc.Update(find);
            }
            else
            {
                this.lc.Insert(ip);
            }
            await Task.CompletedTask;
        }

        public async Task<HashSet<IpRecord>> GetAllIp()
        {
            return await Task.FromResult(this.lc.FindAll().OrderBy(item => item.Ip).ToHashSet());
        }

        public async Task Remove(string id)
        {
            IpRecord ipRecord = this.lc.FindOne(item => item.Id == id);
            if(ipRecord != null)
            {
                bool b = this.lc.Delete(new LiteDB.BsonValue(id));
            }
            await Task.CompletedTask;
        }
        
    }
}
