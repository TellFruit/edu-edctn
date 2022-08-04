﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Interfaces
{
    public interface IFileIoService
    {
        void Write(string data);

        string Read();

        IFileIoService SetPath(string path);
    }
}
