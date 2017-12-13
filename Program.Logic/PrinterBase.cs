using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Program.Logic.Interfaces;
using System.IO;

namespace Program.Logic
{
    abstract class PrinterBase :IPrintable
    {
        public string FileName { get; set; }
        public string Directory { get; set; }
        public ViewSheet Sheet { get; set; }
        public bool CombineSheetsToFile { get; set; } // I don't know how to do this option. figure out!

        private readonly Document _revitDocument;
        private PrintManager _printManager;
        private string _printDriver = "PDF Creator"; // this Print driver nessasary to use from settings.

        public PrinterBase (Document doc)
        {
            _revitDocument = doc;
            _printManager = _revitDocument.PrintManager;
            _printManager.SelectNewPrintDriver(_printDriver);

        }

        public virtual void Start()
        {
            string printingFile = string.Concat(Directory, FileName);
            DeletePrintedFile(printingFile);

            // Printing logic
            _printManager.PrintToFile = true;
            _printManager.PrintRange = PrintRange.Current;
            _printManager.PrintToFileName = printingFile;
            _printManager.SubmitPrint(Sheet);
        }
        
        public virtual void SetPrintStyle()
        {
            throw new NotImplementedException();
            //PrintSetup printSetup = _printManager.PrintSetup;
            //printSetup.CurrentPrintSetting = SelectPrinterStyle(Sheet.SheetNumber); // this needed to compleate. SelectPrintStyle needed to be in another class that represents chosing printer style!
            //_printManager.Apply();
        }
        
        private void DeletePrintedFile(string printedFile)
        {
            if (File.Exists(printedFile)) File.Delete(printedFile);
            
            
        }

    }    
}
