﻿using System;
using Emr.Application.Common.Interfaces;

namespace Emr.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
