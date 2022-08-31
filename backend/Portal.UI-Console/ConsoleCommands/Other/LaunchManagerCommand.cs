﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.UI_Console.ConsoleCommands.Other
{
    internal class LaunchManagerCommand : IConsoleCommand
    {
        private readonly IChooseCommand _chooseCommand;
        private readonly IParseInput _basicParser;

        public LaunchManagerCommand(IChooseCommand chooseCommand, IParseInput basicParser)
        {
            _chooseCommand = chooseCommand;
            _basicParser = basicParser;
        }

        public async Task<bool> Run(params string[] parameters)
        {
            var manager = new CommandManager(_basicParser, _chooseCommand);

            await manager.InitCommandFlow();

            return true;
        }
    }
}
