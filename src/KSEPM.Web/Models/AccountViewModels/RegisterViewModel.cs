using System;
using System.ComponentModel.DataAnnotations;
using KSEPM.Resources.Errors;
using KSEPM.Resources.DisplayNames;
using KSEPM.Web.Infrastructure.Helpers;

namespace KSEPM.Web.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessageResourceType = typeof(ErrorMessage),
                  ErrorMessageResourceName = "ERR_field_empty")]
        [Display(ResourceType = typeof(DisplayName), Name = "DN_RVM_firstname")]
        [StringLength(15, ErrorMessageResourceType = typeof(ErrorMessage), 
                          ErrorMessageResourceName = "ERR_field_shortlong", 
                          MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessage),
                  ErrorMessageResourceName = "ERR_field_empty")]
        [Display(ResourceType = typeof(DisplayName), Name = "DN_RVM_secondname")]
        [StringLength(20, ErrorMessageResourceType = typeof(ErrorMessage),
                          ErrorMessageResourceName = "ERR_field_shortlong",
                          MinimumLength = 3)]
        public string SecondName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessage),
                  ErrorMessageResourceName = "ERR_field_empty")]
        [Display(ResourceType = typeof(DisplayName), Name = "DN_RVM_starttowork")]
        [DataType(DataType.Date)]
        public DateTime StartToWork { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessage),
                  ErrorMessageResourceName = "ERR_field_empty")]
        [EmailAddress(ErrorMessageResourceType = typeof(ErrorMessage),
                      ErrorMessageResourceName = "ERR_field_email_wrongformat",
                      ErrorMessage = null)]
        [Display(ResourceType = typeof(DisplayName), Name = "DN_email")]
        public string Email { get; set; }

        [Required]
        [Display(ResourceType = typeof(DisplayName), Name = "DN_role")]
        public string Role { get; set; }

        public bool IsActive { get;set; }

        [Required]
        [Display(ResourceType = typeof(DisplayName), Name = "DN_password")]
        public string Password { get; set; }

        [Display(ResourceType = typeof(DisplayName), Name = "DN_RVM_description")]
        public string Desription { get; set; }

        [Required]
        [Display(ResourceType = typeof(DisplayName), Name = "DN_RVM_pointtype")]
        public string PointType { get; set; }
    }
}