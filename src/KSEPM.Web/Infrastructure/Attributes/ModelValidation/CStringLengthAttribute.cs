using System;
using System.ComponentModel.DataAnnotations;
using KSEPM.Web.Infrastructure.Helpers;

namespace KSEPM.Web.Infrastructure.Attributes.ModelValidation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class CStringLengthAttribute : StringLengthAttribute
    {
        public CStringLengthAttribute(int minLength, int maxLength, string errorMessage) : base(maxLength)
        {
            MinimumLength = minLength;
            ErrorMessageResourceType = AttributeHelper.GetErrorMessageResourceType();
            ErrorMessageResourceName = errorMessage;
        }
    }
}