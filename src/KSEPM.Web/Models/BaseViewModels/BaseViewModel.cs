using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSEPM.Web.Models.BaseViewModels
{
    // T must be int or string
    public class BaseViewModel<T>
    {
        public T ID { get; set; }
    }
}