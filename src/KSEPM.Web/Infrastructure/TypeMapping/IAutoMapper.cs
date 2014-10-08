using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSEPM.Web.Infrastructure.TypeMapping
{
    public interface IAutoMapper
    {
        T Map<T>(object objectMap);
    }
}
