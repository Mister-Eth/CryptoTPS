﻿using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ETHTPS.API.Tests.StressTests
{
    [TestFixture]
    public class MultiEndpointStressTest
    {
        private readonly string _endpoint;
        private readonly string[] _stressTestPaths;
        private readonly HttpClient _httpClient;
        private readonly int _maxConcurrentRequests;

        public MultiEndpointStressTest()  
        {
            _endpoint = "http://10.10.0.174:50023";
            _stressTestPaths = new string[]
            {
                "/API/v2/InstantData?includeSidechains=true",
                "/API/TPS/Get?provider=All&interval=OneHour&network=Mainnet&includeSidechains=true",
                "/API/GPS/Get?provider=All&interval=OneHour&network=Mainnet&includeSidechains=true"
            };
            _httpClient = new HttpClient() 
            {
                BaseAddress = new Uri(_endpoint)
            };
            _maxConcurrentRequests = 100;
        }

        [Test]
        public void StressTest()
        {
            var requests = _stressTestPaths.SelectMany(path => Enumerable.Range(0, _maxConcurrentRequests).Select(x => Task.Run(async () =>
            {
                await _httpClient.GetAsync(path);
            })));
            Assert.DoesNotThrowAsync(async() =>
            {
                await Task.WhenAll(requests);
            });
        }
    }
}