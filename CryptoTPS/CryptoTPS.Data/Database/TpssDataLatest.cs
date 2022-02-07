using System;
using System.Collections.Generic;

#nullable disable

namespace CryptoTPS.Data.Database
{
    public partial class TpsDataLatest : TPSDataBase
    {
        public double Tps { get; set; }
    }
}
