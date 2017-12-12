using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Program.Logic.Interfaces;

namespace Program.Logic
{
    class ExportDxf: IPrintable
    {
        public string FileName { get; set; }
        public string Directory { get; set; }
        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}
