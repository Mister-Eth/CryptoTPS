using System;
using System.Collections.Generic;

#nullable disable

namespace CryptoTPS.Data.Temp
{
    public partial class TpsdataMax
    {
        public int Id { get; set; }
        public int Provider { get; set; }
        public int Network { get; set; }
        public DateTime Date { get; set; }
        public double MaxTps { get; set; }

        public virtual Provider ProviderNavigation { get; set; }
    }
}
