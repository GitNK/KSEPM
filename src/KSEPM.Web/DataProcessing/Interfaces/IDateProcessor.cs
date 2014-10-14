using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSEPM.Web.Infrastructure.Enums;

namespace KSEPM.Web.DataProcessing.Interfaces
{
    public interface IDateProcessor
    {
        int DateCountToDecrease(TimeInterval timeinterval);
    }
}