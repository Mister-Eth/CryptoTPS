﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Data.Database
{
    public abstract class TPSDataBase
    {
        public int Id { get; set; }
        public int Network { get; set; }
        public int Provider { get; set; }
        public virtual Network NetworkNavigation { get; set; }
        public virtual Provider ProviderNavigation { get; set; }
    }
}