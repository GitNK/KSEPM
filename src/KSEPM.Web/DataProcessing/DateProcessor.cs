﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSEPM.Web.DataProcessing.Interfaces;
using KSEPM.Web.Infrastructure.Enums;

namespace KSEPM.Web.DataProcessing
{
    public class DateProcessor : IDateProcessor
    {
        public int DateCountToDecrease(TimeInterval timeinterval)
        {
            var now = DateTime.Now;

            switch (timeinterval)
            {
                case TimeInterval.Day:
                    return 1;
                case TimeInterval.Week:
                    return ParseDayOfWeek(now.DayOfWeek);
                case TimeInterval.Month:
                    return now.Day;
            }
            return 1;
        }

        private int ParseDayOfWeek(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    return 1;
                case DayOfWeek.Tuesday:
                    return 2;
                case DayOfWeek.Wednesday:
                    return 3;
                case DayOfWeek.Thursday:
                    return 4;
                case DayOfWeek.Friday:
                    return 5;
                case DayOfWeek.Saturday:
                    return 6;
                case DayOfWeek.Sunday:
                    return 7;
            }
            return 1;
        }
    }
}