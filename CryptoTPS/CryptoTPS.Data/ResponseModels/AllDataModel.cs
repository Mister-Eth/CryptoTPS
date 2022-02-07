using CryptoTPS.Data.Database;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Data.ResponseModels
{
    public class AllDataModel
    {
        public IEnumerable<ProviderModel> Providers { get; set; }
        public IDictionary<string, object> MaxData { get; set; }
        public Dictionary<string, IDictionary<string, IEnumerable<DataResponseModel>>> AllTPSData { get; set; }
    }

    public class ProviderModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
