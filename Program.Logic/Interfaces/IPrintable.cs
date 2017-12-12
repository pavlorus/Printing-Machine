using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace Program.Logic.Interfaces
{
    interface IPrintable
    {
        string FileName { set; }
        string Directory { set; }
        ViewSheet Sheet { set; }
        void Start();

    }
}
