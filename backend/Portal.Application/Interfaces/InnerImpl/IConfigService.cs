﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Interfaces.InnerImpl
{
    public interface IConfigService
    {
        string GetSetting(string key);
    }
}
