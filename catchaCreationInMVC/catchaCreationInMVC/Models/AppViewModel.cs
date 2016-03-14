using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catchaCreationInMVC.Models
{ 
    public class AppViewModel
    {
        [Required]
        [Display(Name = "Text")] 
        public string Text { get; set; }
    }

    public static class InfraCons
    {
        public const string CaptchaSessionKey = "CaptchaSessionKey";
    }
}
