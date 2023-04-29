using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcplaza.Models
{
    public class PersonelModels
    {
        public int PersonelNo { get; set; }

        [Required(ErrorMessage="Zorunlu Alan")]
        public string AdSoyad { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Meslek { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Pozisyon { get; set; }

    }
}