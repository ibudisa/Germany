using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AplikacijaNaselja.Models
{
    public class NaseljaViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Can not be blank Naziv")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Can not be blank Drzava")]
        public string Drzava { get; set; }
        [Required(ErrorMessage = "Can not be blank PostanskiBroj")]
        public string PostanskiBroj { get; set; }

    }
}