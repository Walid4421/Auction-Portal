using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Data_TermProject.Models2
{
    public class Usermodel
    {
        
        public int UserId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is Required.")]
        [Display(Name = "First Name: ")]
        public String FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is Required.")]
        [Display(Name = "Last Name: ")]
        public String LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is Required.")]
        [Display(Name = "Email: ")]
        public String Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required.")]
        [Display(Name = "Password: ")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])\w{6,}$", ErrorMessage = "At least 1 uppercase, 1 number  and one lower case letter  Required")]
        [DataType(DataType.Password)]

        public String Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm-Password is Required.")]
        [Display(Name = "Confirm Password: ")]

        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Passwords Do not Match")]
        public String Con_Password { get; set; }//confirmpassword

        [Display(Name = "Mobile Number:")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string PhoneNumber { get; set; }

        public string SuccessMessage { get; set; }
    }
}