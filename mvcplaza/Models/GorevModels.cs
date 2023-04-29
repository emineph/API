using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcplaza.Models
{
    public class GorevModels
    {
        public int GorevNo { get; set; }

        [Required(ErrorMessage="Zorunlu Alan")]
        public string Gorevler { get; set; }

    }
}