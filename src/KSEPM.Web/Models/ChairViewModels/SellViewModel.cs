using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KSEPM.Web.Models.ChairViewModels
{
    public class SellViewModel
    {
        public int SellID { get; set; }
        public int Position { get; set; }
       // public double Discount { get; set; }
        public long SellDate { get; set; }
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