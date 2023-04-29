using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcplaza.Models
{
    public class BlokModels
    {
        public int BlokNo { get; set; }

        [Required(ErrorMessage="Zorunlu Alan")]
        public string Magazalar { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public int MagazaSayisi { get; set; }
    }
}