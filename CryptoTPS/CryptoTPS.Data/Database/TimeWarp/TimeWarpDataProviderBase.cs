using CryptoTPS.Data.Database.TimeWarp.Models;
using CryptoTPS.Data.ResponseModels;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Data.Database.TimeWarp
{
    public abstract class TimeWarpDataProviderBase<TTargetTimeWarpData> : ITimeWarpDataProvider
        where TTargetTimeWarpData: TimeWarpDataBase
    {
        private readonly CryptoTPSContext _context;
        private readonly Func<CryptoTPSContext, DbSet<TTargetTimeWarpData>> _dataSelector;

        protected TimeWarpDataProviderBase(CryptoTPSContext context, Func<CryptoTPSContext, DbSet<TTargetTimeWarpData>> dataSelector, string interval)
        {
            _context = context;
            _dataSelector = dataSelector;
            Interval = interval;
        }

        public string Interval { get; set; }

        public DateTime GetEarliestDate()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DataPoint> GetGasAdjustedTPSAt(long timestamp, string network, int count)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DataPoint> GetGPSAt(long timestamp, string network, int count)
        {
            throw new NotImplementedException();
        }

        public Task<TimeWarpSyncProgressModel> GetSyncProgress(string provider, string network)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DataPoint> GetTPSAt(long timestamp, string network, int count)
        {
            throw new NotImplementedException();
        }
    }
}
