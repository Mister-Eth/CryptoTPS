using CryptoTPS.API.Infrastructure.Services;
using CryptoTPS.API.Infrastructure.Services.Implementations;
using CryptoTPS.Data.Database;
using CryptoTPS.Data.Database.Extensions;
using CryptoTPS.Data.Database.HistoricalDataProviders;
using CryptoTPS.Data.Database.TimeWarp;
using CryptoTPS.Data.Database.TimeWarp.Models;
using CryptoTPS.Data.ResponseModels;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTPS.API.Controllers
{
    [Route("API/TimeWarp/[action]")]
    public class TimeWarpController : ITimeWarpService
    {
        private readonly TimeWarpService _timeWarpService;

        public TimeWarpController(TimeWarpService timeWarpService)
        {
            _timeWarpService = timeWarpService;
        }

        [HttpGet]
        public DateTime GetEarliestDate()
        {
            return ((ITimeWarpService)_timeWarpService).GetEarliestDate();
        }

        [HttpGet]
        public Task<TimeWarpSyncProgressModel> GetSyncProgress(string provider, string network)
        {
            return ((ITimeWarpService)_timeWarpService).GetSyncProgress(provider, network);
        }

        [HttpGet]
        public IEnumerable<DataPoint> GetTPSAt(long timestamp, string network = "Mainnet", int count = 30)
        {
            return ((ITimeWarpService)_timeWarpService).GetTPSAt(timestamp, network, count);
        }

    }
}
