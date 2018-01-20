using ExaminationSubscriberV2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationSubscriberV2.ViewModels
{
    public class ParticipantViewModel
    {
        public int ParticipantId { get; set; }

        [Required(ErrorMessage = "Voornaam is verplicht!"), Display(Name = "Voornaam"), StringLength(30, ErrorMessage = "Voornaam mag niet meer dan 30 karakters bevatten!")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Familienaam"), StringLength(30, ErrorMessage = "Familienaam mag niet meer dan 30 karakters bevatten!")]
        public string LastName { get; set; }

        [Display(Name = "Leeftijd"), RegularExpression(@"^[0-9]{1,2}$", ErrorMessage = "Leeftijd mag uit niet meer dan 2 cijfers bestaan!")]
        public int Age { get; set; }

        [Required, RegularExpression(@"^04[0-9]{8}$", ErrorMessage = "GSM nummer moet bestaan uit 10 nummers en het moet starten met 04!")]
        public string Gsm { get; set; }

        [Required, DataType(DataType.EmailAddress, ErrorMessage = "Gelieve een geldig e-mail adres in te vullen!")]
        public string Email { get; set; }

        [Required, Display(Name = "Licentienummer"), RegularExpression(@"^[0-9]{1,6}$", ErrorMessage = "Licentie nummer mag enkel bestaan uit maximum 6 cijfers!")]
        public string LicenseNumber { get; set; }

        [Required, Display(Name = "Datum tot wanneer licentie geldig is"), DataType(DataType.Date, ErrorMessage = "Gelieve een geldige datum te selecteren!")]
        public DateTime DateTillLicenseIsValid { get; set; } = DateTime.Now.Date;

        [Required, Display(Name = "Graad")]
        public string Grade { get; set; }
        public List<SelectListItem> GradeList { get; } = new List<SelectListItem>
                                                         {
                                                             new SelectListItem { Value = "0e Kyu", Text = "Witte gordel" },
                                                             new SelectListItem { Value = "9e Kyu", Text = "Witte gordel met zwart streepje" },
                                                             new SelectListItem { Value = "9e Kyu", Text = "Rode gordel" },
                                                             new SelectListItem { Value = "8e Kyu", Text = "Gele gordel" },
                                                             new SelectListItem { Value = "7e Kyu", Text = "Oranje gordel" },
                                                             new SelectListItem { Value = "6e Kyu", Text = "Groene gordel" },
                                                             new SelectListItem { Value = "5e Kyu", Text = "Blauwe gordel" },
                                                             new SelectListItem { Value = "4e Kyu", Text = "Blauwe gordel met wit streepje" },
                                                             new SelectListItem { Value = "3e Kyu", Text = "Bruine gordel" },
                                                             new SelectListItem { Value = "2e Kyu", Text = "Bruine gordel met wit streepje" }
                                                         };

        [Required, Display(Name = "Aantal rode lintjes of aantal witte lintjes op rode gordel")]
        public string NumberOfRedRibbons { get; set; }
        public List<SelectListItem> NumberOfRedRibbonsList { get; } = new List<SelectListItem>
                                                                      {
                                                                         new SelectListItem { Value = "0", Text = "0" },
                                                                         new SelectListItem { Value = "1", Text = "1" },
                                                                         new SelectListItem { Value = "2", Text = "2" }
                                                                      };
    }
}
