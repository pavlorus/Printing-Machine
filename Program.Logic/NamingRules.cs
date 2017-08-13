using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Program.Logic.Interfaces;
using Autodesk.Revit.DB;

namespace Program.Logic
{
    class NamingRules: INamingRules
    {
        public List<NamingStorage> NamingStyleDb { get; set; }

        public List<string> ParametersList { get; set; }

        public List<string> PrefixesList { get; set; }

        public List<string> SuffixesList { get; set; }

        public List<Element> InputSheetElements { get; set; }

        public NamingRules(List<Element> inputSheetElements,
                            List<string> parametersList,
                            List<string> prefixesList,
                            List<string> suffixesList)
        {
            ParametersList = parametersList;
            PrefixesList = prefixesList;
            SuffixesList = suffixesList;
            InputSheetElements = inputSheetElements;
        }

        public List<NamingStyle> GetSheetList()
        {
            List<NamingStyle> tempList = new List<NamingStyle>();

            foreach (ViewSheet vs in InputSheetElements)
            {
                string viewSheetId = vs.UniqueId;
                string styledSheetName = GetStyledSheetName(vs);

                tempList.Add(new NamingStyle(viewSheetId, styledSheetName));
            }
            return tempList;
        }

        private string GetStyledSheetName(ViewSheet viewSheet)
        {
            string styledSheetName = String.Empty;

            for (int i = 0; i < ParametersList.Count; i++)
            {
                styledSheetName += (PrefixesList[i] + viewSheet.LookupParameter(ParametersList[i]).AsString()+ SuffixesList[i]);
            }
         
            return styledSheetName;
        }
        
    }
}
