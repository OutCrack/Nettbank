using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbank.Model
{
    public class Konto
    {
        public string persnr { get; set; }

        [Display(Name = "Kontonummer")]
        public string kontoNummer { get; set; }
        [Display(Name = "Opprettet")]
        [DataType(DataType.Date)]
        public string datoOppretning { get; set; }
        [Display(Name = "Saldo")]
        public string saldo { get; set; }
    }
}
