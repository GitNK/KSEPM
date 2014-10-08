using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSEPM.Resources.Errors;

namespace KSEPM.Web.Infrastructure.Helpers
{
    public static class AttributeHelper
    {
        public static Type GetErrorMessageResourceType()
        {
            return typeof (ErrorMessage);
        }
    }
}