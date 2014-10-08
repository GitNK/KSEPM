using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using KSEPM.Web.Infrastructure.Helpers;

namespace KSEPM.Web.Infrastructure.Attributes.ModelValidation
{
    /// <summary>
    /// Custom required attribute. Inherited from RequidedAttribute
    /// Predefine ErrorMessageResourceType
    /// solved issue with ErrorMessage, when it is not null
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class CRequiredAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly bool _allowEmplyStrings;
        public CRequiredAttribute()
        {
           // ErrorMessageResourceName = errorMessage;
           // ErrorMessageResourceType = AttributeHelper.GetErrorMessageResourceType();
        }

        public CRequiredAttribute(string errorMessage, bool allowEmptyStrings)
            : base(errorMessage)
        {
            _allowEmplyStrings = allowEmptyStrings;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return false;
            string str = value as string;
            if (str != null && !_allowEmplyStrings)
                return str.Trim().Length != 0;
            else
                return true;
        }

        public System.Collections.Generic.IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
            {
                
            };
        }
    }
}