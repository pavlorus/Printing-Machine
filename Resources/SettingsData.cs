﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources
{
    [Serializable]
    public class SettingsData : ISettingsData
    {
        //public List<SDFA> MyProperty { get; set; }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Gate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Sex { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    public interface ISettingsData
    {
        string Name { get; set; }
        string Gate { get; set; }
        string Sex { get; set; }

    }
}
