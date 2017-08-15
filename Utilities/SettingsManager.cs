using Program.Logic;
using Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;



namespace Utilities
{
    class SettingsManager
    {
        private static string _settingsFileName;
        private static string _fileExtension;
        private static ISettingsData _data = new SettingsData();

        public static ISettingsData Data { get => _data; set => _data = value; }

        private static string GetFileName()
        {
            _fileExtension = "." + "xml";
            _settingsFileName = Path.GetFileNameWithoutExtension(System.Windows.Forms.Application.ExecutablePath) + _fileExtension;
            return _settingsFileName;
        }

        // Load configuration file
        public static void Load()
        {
            string fullSettingsFileNamePath = GetFileName();
            if (File.Exists(fullSettingsFileNamePath))
            {
                StreamReader srReader = File.OpenText(fullSettingsFileNamePath);
                Type tType = Data.GetType();
                XmlSerializer xsSerializer = new XmlSerializer(tType);
                object oData = xsSerializer.Deserialize(srReader);
                Data = (SettingsData)oData;
                srReader.Close();
            }
        }

        // Save configuration file
        public static void Save()
        {
            string fullSettingsFileNamePath = GetFileName();
            StreamWriter swWriter = File.CreateText(fullSettingsFileNamePath);
            Type tType = Data.GetType();
            if (tType.IsSerializable)
            {
                XmlSerializer xsSerializer = new XmlSerializer(tType);
                xsSerializer.Serialize(swWriter, Data);
                swWriter.Close();
            }
        }
    }
}
