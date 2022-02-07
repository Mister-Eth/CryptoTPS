using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Services.BlockchainServices
{
    public class TPSInfo
    {
        public int BlockNumber { get; set; }
        public DateTime Date { get; set; }
        public double TPS { get; set; }
    }
}
