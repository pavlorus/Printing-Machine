using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Program.Logic.Interfaces;

namespace Program.Logic
{
    abstract class PrinterBase :IPrintable
    {
        public string FileName { get; set; }
        public string Directory { get; set; }
        public abstract void Start();

        public virtual void GetPrintStyle()
        {
            
        }

    }
}
