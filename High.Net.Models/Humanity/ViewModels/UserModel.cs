using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High.Net.Models.Humanity.ViewModels
{
    public class UserModel
    {
        [Required(ErrorMessage = "User name is required!")]
        [Display(Name = "Username*")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [Display(Name = "Password*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
