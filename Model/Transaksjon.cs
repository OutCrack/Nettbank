using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbank.Model
{
    public class Transaksjon
    {
        public int id { get; set; }

        [Display(Name = "Beløp")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Ikke gylding beløp")]
        public string beløp { get; set; }

        [Display(Name = "Dato")]
        [Required(ErrorMessage = "Datoen betalingen skal utføres må oppgis")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd.MM.yyyy}")]
        public string dato { get; set; }

        [Display(Name = "Fra Konto")]
        [RegularExpression(@"\d{11}", ErrorMessage = "Ikke gylding kontonummer (11 siffer)")]
        public string fraKonto { get; set; }

        [Display(Name = "Til Konto")]
        [RegularExpression(@"\d{11}", ErrorMessage = "Ikke gylding kontonummer (11 siffer)")]
        public string tilKonto { get; set; }

        [Display(Name = "KID")]
        [Required(ErrorMessage = "KID nummer eller en beskjed må oppgis")]
        public string kid { get; set; }

        [Display(Name = "Bekreft")]
        public bool bekreftet { get; set; }
    }
}
