﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace HW6.Interfaces
{
    public interface ILogger
    {
        void Write(string text);
    }
}
