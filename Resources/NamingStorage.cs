using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources
{
    [Serializable]
    class NamingStorage
    {
        public string PreffixToParameter { get; set; }

        public string ParameterName { get; set; }

        public string SuffixToParameter { get; set; }

        public string TypeOfDataParameter { get; set; }

        public NamingStorage(string preffixToParameter, string parameterName, string suffixToParameter, string typeOfDataParameter)
        {
            PreffixToParameter = preffixToParameter;
            ParameterName = parameterName;
            SuffixToParameter = suffixToParameter;
            TypeOfDataParameter = typeOfDataParameter;
        }
    }
}



