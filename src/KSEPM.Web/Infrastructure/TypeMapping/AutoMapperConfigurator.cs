using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace KSEPM.Web.Infrastructure.TypeMapping
{
    public class AutoMapperConfigurator
    {
        public void Configure(IEnumerable<IAutoMapperTypeConfigurator> autoMapperTypeConfigurators)
        {
            autoMapperTypeConfigurators.ToList().ForEach(x => x.Configure());

            Mapper.AssertConfigurationIsValid();
        }
    }
}