using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSEPM.Web.DataProcessing;
using KSEPM.Web.DataProcessing.Interfaces;
using KSEPM.Web.Infrastructure.Enums;
using KSEPM.Web.Infrastructure.Interfaces;

namespace KSEPM.Web.Infrastructure
{
    public static class ExtentionMethods
    {
        public static List<T> FilterByDate<T>(this IEnumerable<T> list, TimeInterval timespan) where T : IDateFilter
        {
            var dateProcessor = new DateProcessor();
            return list.ToList().FindAll(x => x.SellDate >= DateTime.Now.AddDays(-dateProcessor.DateCountToDecrease(timespan)));
        }
    }
}