using System;
using System.Collections.Generic;

#nullable disable

namespace CryptoTPS.Data.Temp
{
    public partial class TpsdataLatest
    {
        public int Id { get; set; }
        public int Provider { get; set; }
        public int Network { get; set; }
        public double Tps { get; set; }

        public virtual Provider ProviderNavigation { get; set; }
    }
}
