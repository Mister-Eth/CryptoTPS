using CryptoTPS.API.Infrastructure.Services;
using CryptoTPS.API.Infrastructure.Services.Implementations;
using CryptoTPS.Data.Database;
using CryptoTPS.Data.Database.Extensions;
using CryptoTPS.Data.Database.HistoricalDataProviders;
using CryptoTPS.Data.ResponseModels;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTPS.API.Controllers
{
    [Route("API/TPS/[action]")]
    public class TPSController : IPSService
    {
        private readonly TPSService _tpsService;

        public TPSController(TPSService tpsService)
        {
            _tpsService = tpsService;
        }

        [HttpGet]
        public IDictionary<string, IEnumerable<DataResponseModel>> GeMonthlyDataByYear(string provider, int year, string network = "Mainnet", bool includeSidechains = true)
        {
            return ((IPSController<DataPoint, DataResponseModel>)_tpsService).GeMonthlyDataByYear(provider, year, network, includeSidechains);
        }

        [HttpGet]
        public IDictionary<string, IEnumerable<DataResponseModel>> Get(string provider, string interval, string network = "Mainnet", bool includeSidechains = true)
        {
            return ((IPSController<DataPoint, DataResponseModel>)_tpsService).Get(provider, interval, network, includeSidechains);
        }

        [HttpGet]
        public IDictionary<string, IEnumerable<DataPoint>> Instant(bool includeSidechains = true)
        {
            return ((IPSController<DataPoint, DataResponseModel>)_tpsService).Instant(includeSidechains);
        }

        [HttpGet]
        public IDictionary<string, DataPoint> Max(string provider, string network = "Mainnet")
        {
            return ((IPSController<DataPoint, DataResponseModel>)_tpsService).Max(provider, network);
        }
    }
}
