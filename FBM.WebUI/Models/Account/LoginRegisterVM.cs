using FBM.Core.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace FBM.WebUI.Models.Account
{
    public class LoginRegisterVM
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(128)]
        [Display(Name = "Email", ResourceType = typeof(Resources))]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 6)]
        [Display(Name = "UserName", ResourceType = typeof(Resources))]
        public string UserName { get; set; }


        [Required]
        [Display(Name = "Password", ResourceType = typeof(Resources))]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [MembershipPassword()]
        public string Password { get; set; }

        [Required]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resources))]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [MembershipPassword()]
        public string ConfirmPassword { get; set; }


        [Display(Name = "RememberMe", ResourceType = typeof(Resources))]
        public bool RememberMe { get; set; }
    }
}