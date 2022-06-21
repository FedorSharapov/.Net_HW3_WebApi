using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.UI
{
    public interface IConsoleUI
    {
        Task ReadCustomerInfoByIdAsync();
        Task CreateRandomCustomerAsync();
        void Run();
    }
}
