using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaiwellFuture.ViewModels;

namespace HaiwellFuture.Services
{
    public interface IHMISearch
    {
        Task<List<HMISearchViewModel>> GetOnlineAsync();
    }
}
