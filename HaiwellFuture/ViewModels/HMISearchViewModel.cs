using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace HaiwellFuture.ViewModels
{
    /// <summary>
    /// company=haiwell,ip=192.168.100.183,hostname=183SC_LHG_03,pncode=1712013110060100045,versoft=2.0.9.0,projectname=Demo project,wlanip=0.0.0.0
    /// </summary>
    public class HMISearchViewModel
    {
        public string company { get; set; }
        public string ip { get; set; }
        public string hostname { get; set; }
        public string pncode { get; set; }
        public string versoft { get; set; }
        public string projectname { get; set; }
        public HMISearchViewModel()
        {

        }
        public HMISearchViewModel(string search)
        {
            PropertyInfo[] pis = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            string[] items = search.Split(',');
            foreach(string item in items)
            {
                string[] keyvalue = item.Split('=');
                PropertyInfo pi = pis.SingleOrDefault(x => x.Name == keyvalue[0]);
                if(pi != null)
                {
                    pi.SetValue(this, keyvalue[1]);
                }
            }
        }
    }
}
