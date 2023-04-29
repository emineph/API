using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcplaza.Models
{
    public class Plazalar
    {
        public int PlazaNo { get; set; }

        [Required(ErrorMessage="Zorunlu Alan")]
        public string PlazaAdi { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Bolum { get; set; }

    }
}