using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text;
using HaiwellFuture.ViewModels;
using System.Collections.Concurrent;
using Microsoft.Extensions.Configuration;

namespace HaiwellFuture.Services
{
    /// <summary>
    /// HMI搜索服务
    /// </summary>
    public class HMISearchServices : IHMISearch
    {
        private UdpClient udpClient;
        private ConcurrentDictionary<string, HMISearchViewModel> dict = new ConcurrentDictionary<string, HMISearchViewModel>();

        public HMISearchServices(IConfiguration configuration)
        {
            string localIp = configuration.GetValue<string>("LocalIp");
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(localIp), 0);
            this.udpClient = new UdpClient(iPEndPoint);
            Task.Run(() => {
                this.Send();
            });
            Task.Run(() => {
                this.Run();
            });
        }
        private async void Send()
        {
            byte[] bys = Encoding.UTF8.GetBytes("haiwell scada");
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Broadcast, 3366);
            while (true)
            {
                this.dict.Clear();
                int len = await this.udpClient.SendAsync(bys, bys.Length, iPEndPoint);
                await Task.Delay(10000);
            }
        }
        private async void Run()
        {
            while (true)
            {
                UdpReceiveResult result = await this.udpClient.ReceiveAsync();
                string res = Encoding.UTF8.GetString(result.Buffer);
                if (!string.IsNullOrEmpty(res))
                {
                    HMISearchViewModel hMI = new HMISearchViewModel(res);
                    if (!this.dict.ContainsKey(hMI.ip))
                    {
                        this.dict.TryAdd(hMI.ip, hMI);
                    }
                }
            }
        }
        /// <summary>
        /// 获取在线HMI
        /// </summary>
        /// <returns></returns>
        public async Task<List<HMISearchViewModel>> GetOnlineAsync()
        {
            await Task.CompletedTask;
            return this.dict.Values.OrderBy(item => item.ip).ToList();
        }
    }
}
