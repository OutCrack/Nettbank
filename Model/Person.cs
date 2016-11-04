using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbank.Model
{
    public class Person
    {
        [Display(Name = "Personnummer")]
        [RegularExpression(@"\d{11}", ErrorMessage = "Ikke gylding personnummer")]
        public string personnummer { get; set; }

        [Display(Name = "Fornavn")]
        [RegularExpression(@"[A-ZÆØÅa-zæøå ]{1,40}", ErrorMessage = "Ikke gylding fornavn")]
        public string fornavn { get; set; }

        [Display(Name = "Etternavn")]
        [RegularExpression(@"[A-ZÆØÅa-zæøå ]{1,40}", ErrorMessage = "Ikke gylding etternavn")]
        public string etternavn { get; set; }

        [Display(Name = "Adresse")]
        [RegularExpression(@"[0-9A-ZÆØÅa-zæøå ]{1,40}", ErrorMessage = "Ikke gylding adresse")]
        public string adresse { get; set; }

        [Display(Name = "PostNr")]
        [RegularExpression(@"\d{4}", ErrorMessage = "Ikke gylding postnummer")]
        public string postNr { get; set; }

        [Display(Name = "Poststed")]
        [RegularExpression(@"[A-ZÆØÅa-zæøå ]{1,40}", ErrorMessage = "Ikke gylding Poststed")]
        public string poststed { get; set; }

        [Display(Name = "Telefonnr")]
        [RegularExpression(@"\d{8,12}", ErrorMessage = "Ikke gylding telefonnummer")]
        public string telefonnr { get; set; }

        [Display(Name = "Passord")]
        [Required(ErrorMessage = "Passord må oppgis")]
        public string passord { get; set; }

        [Display(Name = "Engangskode")]
        [RegularExpression(@"\d{6}", ErrorMessage = "Ikke gylding engangskode")]
        public string engangskode { get; set; }
    }
}
