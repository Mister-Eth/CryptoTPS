using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Services.BlockchainServices
{
    public class BlockInfo
    {
        public int BlockNumber { get; set; }
        public int TransactionCount { get; set; }
        public DateTime Date { get; set; }
        public bool Settled { get; set; } = true;

        public static TPSInfo operator -(BlockInfo a, BlockInfo b)
        {
            return new TPSInfo()
            {
                Date = a.Date,
                BlockNumber = a.BlockNumber,
                TPS = (a.TransactionCount) / (a.Date.Subtract(b.Date).TotalSeconds)
            };
        }
    }
}
