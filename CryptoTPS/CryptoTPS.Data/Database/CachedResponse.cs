﻿using System;
using System.Collections.Generic;

#nullable disable

namespace CryptoTPS.Data.Database
{
    public partial class CachedResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Json { get; set; }
    }
}
