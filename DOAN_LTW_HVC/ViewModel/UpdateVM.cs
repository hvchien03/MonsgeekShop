using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.SqlServer.Server;

namespace DOAN_LTW_HVC.ViewModel
{
    public class UpdateVM
    {
        [Required]
        [RegularExpression(@"^[0-9a-zA-Z ]*$", ErrorMessage = "Bạn không được nhập ký tự đặc biệt")]
        public string Username {  get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email {  get; set; }
        public string PhoneNumber { get; set; }
        public string Address {  get; set; }
    }
}