using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Services.Config
{
    internal class ConfigService : IConfigService
    {
        public string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key] ?? "";
        }
    }
}
