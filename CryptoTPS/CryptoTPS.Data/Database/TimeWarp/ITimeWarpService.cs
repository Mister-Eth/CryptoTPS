using CryptoTPS.Data.Database.TimeWarp.Models;
using CryptoTPS.Data.ResponseModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTPS.Data.Database.TimeWarp
{
    public interface ITimeWarpService
    {
        public DateTime GetEarliestDate();
        public IEnumerable<DataPoint> GetTPSAt(long timestamp, string network, int count);
        public Task<TimeWarpSyncProgressModel> GetSyncProgress(string provider, string network);
    }
}
