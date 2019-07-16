using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hololens.Obeya.Core.Services.HamburguerMenuService
{
    public interface IHamburguerMenuService
    {
        void ShowCustomers();

        void ShowStrategy();

        void ShowTasks();

        void ShowWorkforce();
    }
}
