﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModels
{
    public class LogInViewModel
    {
        public string UserName { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
