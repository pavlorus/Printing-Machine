﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Logic
{
    class NamingStyleDb
    {
        public string PreffixToParameter { get; set; }

        public string ParameterName { get; set; }

        public string SuffixToParameter { get; set; }

        public string TypeOfDataParameter { get; set; }

        public NamingStyleDb(string preffixToParameter, string parameterName, string suffixToParameter, string typeOfDataParameter)
        {
            PreffixToParameter = preffixToParameter;
            ParameterName = parameterName;
            SuffixToParameter = suffixToParameter;
            TypeOfDataParameter = typeOfDataParameter;
        }
    }
}



