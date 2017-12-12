using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Program.Logic.Interfaces;

namespace Program.Logic
{
    abstract class PrinterBase :IPrintable
    {
        public string FileName { get; set; }
        public string Directory { get; set; }
        public ViewSheet Sheet { get; set; }
        public bool CombineSheetsToFile { get; set; }

        private readonly Document _revitDocument;

        protected PrinterBase (Document doc)
        {
            _revitDocument = doc;

        }

        public virtual void Start()
        {
            PrintManager printManager = _revitDocument.PrintManager;
            printManager.PrintToFile = true;
            printManager.PrintRange = PrintRange.Current;
            printManager.PrintToFileName = string.Concat(Directory, FileName);
            printManager.SubmitPrint(Sheet);
        }

        public virtual void Start(List<ViewSheet> viewSheetList)
        {
            
        }

        public virtual void SetPrintStyle()
        {
            PrintManager printManager = _revitDocument.PrintManager;
            PrintSetup printSetup = printManager.PrintSetup;
            
            printSetup.CurrentPrintSetting = SelectPrinterStyle(Sheet.SheetNumber); // this needed to compleate. SelectPrintStyle needed to be in another class that represents chosing printer style!
            printManager.Apply();
        }

    }
}
