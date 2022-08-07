using Portal.Application.DTO;
using Portal.Application.Interfaces.InnerImpl.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.UI_Console
{
    internal class ConsoleApp
    {
        private readonly ICommandManager _manager;

        public ConsoleApp(ICommandManager manager)
        {
            _manager = manager;
        }

        public async Task Run()
        {
            await _manager.InitCommandFlow();
        }
    }
}
