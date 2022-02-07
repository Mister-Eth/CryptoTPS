using System;
using System.Collections.Generic;

#nullable disable

namespace CryptoTPS.Data.Temp
{
    public partial class TimeWarpDataMinute
    {
        public int Id { get; set; }
        public int Network { get; set; }
        public int Provider { get; set; }
        public int? Block { get; set; }
        public DateTime StartDate { get; set; }
        public double AverageTps { get; set; }

        public virtual Provider ProviderNavigation { get; set; }
    }
}
