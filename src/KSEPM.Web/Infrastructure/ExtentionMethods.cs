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
        public static IEnumerable<T> FilterByDate<T>(this IEnumerable<T> list, TimeInterval timespan) where T : IDateFilter
        {
            var dateProcessor = new DateProcessor();
            return list.Where(x => x.SellDate >= DateTime.Now.AddDays(-dateProcessor.DateCountToDecrease(timespan)));
        }

        public static IEnumerable<T> FilterByDate<T>(this IEnumerable<T> list, Month month) where T : IDateFilter
        {
            var dateProcessor = new DateProcessor();
            var timeInterval = dateProcessor.GetDateTimeInterval(month);
            return list.Where(x => x.SellDate >= timeInterval.From && x.SellDate <= timeInterval.Until);
        }

        public static int GetEnumValue<T>(this T enumName)
        {
            return (int)Enum.Parse(enumName.GetType(), enumName.ToString());
        }

        public static T ParseToEnum<T>(this object enumString)
        {
            return (T)Enum.Parse(typeof(T), enumString.ToString());
        }
    }
}