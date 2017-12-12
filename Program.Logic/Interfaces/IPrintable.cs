﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Logic.Interfaces
{
    interface IPrintable
    {
        string FileName { set; }
        string Directory { set; }

        void Start();

    }
}
