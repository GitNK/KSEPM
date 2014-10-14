using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using KSEPM.Web.Infrastructure.Interfaces;
using KSEPM.Web.Models.BaseViewModels;

namespace KSEPM.Web.Models.ChairViewModels
{
    public class SellViewModel : BaseViewModel<int>
    {
        public int Position { get; set; }
       // public double Discount { get; set; }
        public long Date { get; set; }
        public double Ammount { get; set; }
        public double Points { get; set; }
        public string Achievements { get; set; }
        public ChairViewModel Chair { get; set; }
        public SellerViewModel Seller { get; set; }
        public SellPointViewModel SellPoint { get; set; }
        public IEnumerable<ChairOptionViewModel> ChairOptions { get; set; }
        public IEnumerable<int> ChairOptionIDs { get; set; }
    }
}