using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Logic.Interfaces
{
    interface IFileManager
    {
        string FileName { get; set; }
        string Path { get; set; }
        string Filter { get; set; }
        string FileNameExtension { get; set; }
        string Title { get; set; }
        void OpenFile();
        void SaveFile();

    }
}
