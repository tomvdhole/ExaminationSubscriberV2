
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationSubscriberV2.Models
{
    public class Participant
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Gsm { get; set; }

        public string Email { get; set; }

        public string LicenseNumber { get; set; }

        public DateTime DateTillLicenseIsValid { get; set; }

        public string Grade { get; set; }

        public string NumberOfRedRibbons { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
