﻿using CryptoTPS.Data.Database;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Data.ResponseModels.HomePage
{
    public class ProviderInfo
    {
        public double MaxTPS { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
