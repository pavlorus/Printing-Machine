using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using pdfforge.PDFCreator.UI.ComWrapper;
using System.Windows.Forms;
using Autodesk.Revit.UI;
using System.IO;

namespace Program.Logic
{
    class PrinterPdfCreator :PrinterBase
    {
        private bool _isTypeInitialized;

        /// <summary>
        /// This class is for using with PDF Creator API Driver.
        /// </summary>
        /// <param name="doc">input Revit Document, for print</param>
        public PrinterPdfCreator(Document doc) : base(doc)
        {
           
        }

        public override void Start()
        {
            string convertedFilePath = Directory + FileName;
            
            base.Start(); // Calling standart Revit print, and sendig to PDF driver. Driver was initialized and waiting for

            ConvertToPdf(convertedFilePath);
            
        }

        private void ConvertToPdf(string _convertedFilePath)
        {
            var jobQueue = CreateQueue();
            jobQueue.Initialize();

            try
            {
                if (File.Exists(_convertedFilePath))
                {
                    File.Delete(_convertedFilePath);
                }

                if (!jobQueue.WaitForJob(20))
                {
                    TaskDialog.Show("Info", "The job didn't arrive within 20 seconds"); //here I need write to log file!
                }
                else
                {
                    var printJob = jobQueue.NextJob;

                    printJob.SetProfileByGuid("DefaultGuid"); // this I need to set in settings file, for use created print settings!!!

                    printJob.SetProfileSetting("OpenViewer", "False");
                    printJob.SetProfileSetting("OpenWithPdfArchitect", "False");
                    //printJob.SetProfileSetting("PdfSettings.PageOrientation", "Landscape");
                    // Note: Orientation I need to define programmatically

                    printJob.ConvertTo(_convertedFilePath);

                }
                
            }
            catch (Exception err)
            {
                MessageBox.Show("An error occured: " + err.Message);
            }
            finally
            {
                jobQueue.ReleaseCom();
            }
        }

        private Queue CreateQueue()
        {
            // This needs to be done once to make the ComWrapper work reliably.
            if (!_isTypeInitialized)
            {
                Type queueType = Type.GetTypeFromProgID("PDFCreator.JobQueue");
                Activator.CreateInstance(queueType);
                _isTypeInitialized = true;
            }

            return new Queue();
        }

    }
    
    
}
