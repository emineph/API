using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mvcplaza.Models
{
    public class HizmetModel
    {
        public int HizmetNo { get; set; }
        [Required(ErrorMessage ="Zorunlu Alan")]
        public string Hizmetler { get; set; }
    }
}