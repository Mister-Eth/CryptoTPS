using System;
using System.Collections.Generic;

#nullable disable

namespace CryptoTPS.Data.Database
{
    public partial class TpsDataMax : TPSDataBase
    {
        public DateTime Date { get; set; }
        public double MaxTps { get; set; }
    }
}
