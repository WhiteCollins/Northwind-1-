﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Infraestructure.Data.Base
{
    public class NotificationResult
    {
        public bool Success { get; set; }
        public string? Message {  get; set; }
    }
}
