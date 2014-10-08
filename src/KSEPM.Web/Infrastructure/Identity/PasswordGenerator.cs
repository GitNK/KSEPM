using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSEPM.Web.Infrastructure.Identity
{
    public static class PasswordGenerator
    {
        public static string Generate()
        {
            return Generate(8);
        }

        public static string Generate(int length)
        {
            return Guid.NewGuid().ToString().Substring(0, length);
        }
    }
}