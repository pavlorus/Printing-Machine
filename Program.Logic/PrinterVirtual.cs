using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace Program.Logic
{
    class PrinterVirtual:PrinterBase
    {
        public PrinterVirtual(Document doc) : base(doc)
        {
        }

        public override void Start()
        {
            throw new NotImplementedException();
        }
    }
}
