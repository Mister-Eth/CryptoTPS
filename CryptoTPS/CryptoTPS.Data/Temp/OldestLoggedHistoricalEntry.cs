using System;
using System.Collections.Generic;

#nullable disable

namespace CryptoTPS.Data.Temp
{
    public partial class OldestLoggedHistoricalEntry
    {
        public int Id { get; set; }
        public int Network { get; set; }
        public int Provider { get; set; }
        public int OldestBlock { get; set; }

        public virtual Provider ProviderNavigation { get; set; }
    }
}
