using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTPS.Data.Database.HistoricalDataProviders
{
    public class OneDayHistoricalDataProvider : HistoricalDataProviderBase<TpsandGasDataDay>
    {
        public OneDayHistoricalDataProvider(CryptoTPSContext context) : base("OneDay", context, x => x.TpsandGasDataDays, TimeSpan.FromDays(1))
        {

        }
    }
}
