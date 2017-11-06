using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Program.Logic.Interfaces;
using Autodesk.Revit.DB;
using Resources;


namespace Program.Logic
{
    class NamingManager: INamingManager
    {
        public List<INamingStorage> NamingStyleDb { get; set; }

        private Document _doc;

        public NamingManager(Document doc)
        {
            _doc = doc;
        }

        public string GetStyledSheetName(ViewSheet viewSheet)
        {
            string styledSheetName = String.Empty;

            foreach (var namStyle in NamingStyleDb)
            {
                styledSheetName += (namStyle.PreffixToParameter + GetValueFromParameter(viewSheet, namStyle.ParameterName, namStyle.TypeOfDataParameter)
                    + namStyle.SuffixToParameter);
            }
            return styledSheetName;
        }

        private string GetValueFromParameter(ViewSheet viewSheet, string param, string typeOfParameter)
        {

            string projectInfoValue = string.Empty;

            if (typeOfParameter == "Autodesk.Revit.DB.ProjectInfo")
            {
                projectInfoValue = _doc.ProjectInformation.LookupParameter(param).AsString();
                return projectInfoValue;
            }
            
            if (typeOfParameter == "Autodesk.Revit.DB.ViewSheet")
            {
                projectInfoValue = viewSheet.LookupParameter(param).AsString();
                return projectInfoValue;
            }

            if (typeOfParameter == "System")
            {
                return "None";
            }

            return projectInfoValue;
        }
        
    }
}
