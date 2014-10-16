using System;

namespace KSEPM.Web.DataProcessing.Common
{
    public class DateTimeInterval
    {
        public DateTimeInterval(DateTime from, DateTime until)
        {
            From = from;
            Until = until;
        }
        public DateTime From { get; set; }
        public DateTime Until { get; set; }
    }
}