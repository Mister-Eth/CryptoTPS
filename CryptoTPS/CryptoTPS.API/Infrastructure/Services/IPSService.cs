using CryptoTPS.Data.ResponseModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTPS.API.Infrastructure.Services
{
    public interface IPSService : IPSController<DataPoint, DataResponseModel>
    {
    }
}
