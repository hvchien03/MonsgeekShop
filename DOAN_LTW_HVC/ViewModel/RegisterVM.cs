using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DOAN_LTW_HVC.ViewModel
{
    public class RegisterVM
    {
        [Required]
        [RegularExpression(@"^[0-9a-zA-Z ]*$", ErrorMessage = "Bạn không được nhập ký tự đặc biệt")]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Chỉ được nhập số")]
        public string PhoneNumber {  get; set; }
        public string Address { get; set; }

    }
}