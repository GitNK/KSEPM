using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KSEPM.Web.Infrastructure.TypeMapping;
using KSEPM.Web.Models.ChairViewModels;

namespace KSEPM.Web.Infrastructure.AutoMappingConfigurations
{
    public class ChairsToChairViewModel : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
           /* Mapper.CreateMap<Chair, ChairViewModel>()
                .ForSourceMember(x => x.Price, opt => opt.Ignore())
                .ForSourceMember(x => x.ChairOptions, opt => opt.Ignore())
                .ForSourceMember(x => x.ChairLine, opt => opt.Ignore())
                .ForSourceMember(x => x.ID, opt => opt.Ignore());*/
        }
    }
}
