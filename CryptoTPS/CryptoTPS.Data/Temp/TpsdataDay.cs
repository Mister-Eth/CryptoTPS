using System;
using System.Collections.Generic;

#nullable disable

namespace CryptoTPS.Data.Temp
{
    public partial class TpsdataDay
    {
        public int Id { get; set; }
        public int Network { get; set; }
        public int Provider { get; set; }
        public DateTime StartDate { get; set; }
        public double AverageTps { get; set; }
        public int ReadingsCount { get; set; }
        public string OclhJson { get; set; }

        public virtual Provider ProviderNavigation { get; set; }
    }
}
