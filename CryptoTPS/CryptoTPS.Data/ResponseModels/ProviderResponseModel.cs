using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Data.ResponseModels
{
    public class ProviderResponseModel
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public ProviderResponseModel SubchainOf { get; set; }
    }
}
