﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Orgchart.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember")]
        public bool RememberIdentity { get; set; }
        public string ReturnUrl { get; set; }
    }
}
