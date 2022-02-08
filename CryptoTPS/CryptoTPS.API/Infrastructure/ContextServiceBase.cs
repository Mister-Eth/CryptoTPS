using CryptoTPS.Data;
using CryptoTPS.Data.Database;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTPS.API.Infrastructure
{
    public abstract class ContextServiceBase
    {
        protected CryptoTPSContext Context { get; private set; }

        protected ContextServiceBase(CryptoTPSContext context)
        {
            Context = context;
        }

        protected IEnumerable<string> TimeIntervals()
        {
            foreach (var interval in Enum.GetValues(typeof(TimeInterval)))
            {
                if (interval.ToString() == "Instant" || interval.ToString() == "Latest")
                    continue;

                yield return interval.ToString();
            }
        }
    }
}
