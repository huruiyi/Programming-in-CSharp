﻿using System.ComponentModel.DataAnnotations;

namespace MVC.Sample.Models
{
    public class LogOnViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}