using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utilities
{
    public class TextCorrection
    {
        public static string DeleteSpecificCharacters(string inputString, string replacedCharater)
        {
            return Regex.Replace(inputString, @"[^\w\d\s]", replacedCharater);

        }
    }
}
