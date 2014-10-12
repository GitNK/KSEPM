using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using KSEPM.Resources.DisplayNames;
using KSEPM.Web.Infrastructure.Attributes;
using KSEPM.Web.Models.BaseViewModels;

namespace KSEPM.Web.Models.ChairViewModels
{
    public class ChairViewModel : NameBaseViewModel<int>
    {
        public string ChairLineName { get; set; }
        public IEnumerable<ChairOptionGroupViewModel> ChairOptionGroups { get; set; }
    }

    public class ChairOptionGroupViewModel
    {
        public string ChairTypeName { get; set; }
        public IEnumerable<ChairOptionViewModel> ChairOptionNames { get; set; }
        public bool IsMultipleSelect { get; set; }
    }

    /// <summary>
    /// Used in AddSell view to in chair drop down list
    /// </summary>
    public class ChairLineViewModel
    {
        public string ChairLineName { get; set; }
        public IEnumerable<ChairViewModel> Chairs { get; set; }
    }
}