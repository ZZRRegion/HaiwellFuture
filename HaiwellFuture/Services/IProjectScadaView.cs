using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaiwellFuture.Services
{
    public interface IProjectScadaView
    {
        void SetFile(string fileName);
        ViewModels.ProjectViewModel GetViewModel();
    }
}
