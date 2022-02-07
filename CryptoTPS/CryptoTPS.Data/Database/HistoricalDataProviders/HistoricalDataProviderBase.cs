using CryptoTPS.Data.Extensions;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Data.Database.HistoricalDataProviders
{
    public abstract class HistoricalDataProviderBase<TTargetHistoricalData> : IHistoricalDataProvider
        where TTargetHistoricalData: TimedTPSData
    {
        private readonly CryptoTPSContext _context;
        private readonly Func<CryptoTPSContext, DbSet<TTargetHistoricalData>> _dataSelector;
        private readonly TimeSpan _maxAge;

        protected HistoricalDataProviderBase(string interval, CryptoTPSContext context, Func<CryptoTPSContext, DbSet<TTargetHistoricalData>> dataSelector, TimeSpan maxAge)
        {
            Interval = interval;
            _context = context;
            _dataSelector = dataSelector;
            _maxAge = maxAge;
        }

        public string Interval { get; private set; }

        public IEnumerable<TimedTPSData> GetData(string provider, string network)
        {
            IEnumerable<TimedTPSData> result;
            lock (_context.LockObj)
            {
                result = _dataSelector(_context).Where(x => x.NetworkNavigation.Name == network && x.ProviderNavigation.Name == provider).DistinctBy(x => x.StartDate).OrderBy(x => x.StartDate).ToList().Where(x => DateTime.Now.ToUniversalTime().Subtract(x.StartDate) <= _maxAge);
            }
            return result;
        }
    }
}
