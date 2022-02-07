using CryptoTPS.Data.Database;
using CryptoTPS.Data.Database.HistoricalDataProviders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTPS.API.Infrastructure.Services
{
    public abstract class HistoricalMethodsServiceBase : ContextServiceBase
    {
        protected IEnumerable<IHistoricalDataProvider> HistoricalDataProviders { get; set; }
        protected HistoricalMethodsServiceBase(CryptoTPSContext context, IEnumerable<IHistoricalDataProvider> historicalDataProviders) : base(context)
        {
            HistoricalDataProviders = historicalDataProviders;
        }

        protected IEnumerable<TimedTPSData> GetHistoricalData(string interval, string provider, string network)
        {
            if (HistoricalDataProviders.Any(x => x.Interval == interval))
            {
                var dataProvider = HistoricalDataProviders.First(x => x.Interval == interval);
                return dataProvider.GetData(provider, network);
            }
            else
            {
                return new List<TimedTPSData>();
            }
        }
    }
}
