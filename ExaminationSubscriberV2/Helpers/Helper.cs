using ExaminationSubscriberV2.Models;
using ExaminationSubscriberV2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationSubscriberV2.Helpers
{
    public static class Helper
    {
        public static Participant ParticipantViewModelToParticipant(ParticipantViewModel participantViewModel)
        {
            return new Participant
            {
                Id = participantViewModel.ParticipantId,
                FirstName = participantViewModel.FirstName,
                LastName = participantViewModel.LastName,
                Age = participantViewModel.Age,
                Gsm = participantViewModel.Gsm,
                Email = participantViewModel.Email,
                LicenseNumber = participantViewModel.LicenseNumber,
                DateTillLicenseIsValid = participantViewModel.DateTillLicenseIsValid,
                Grade = participantViewModel.Grade,
                NumberOfRedRibbons = participantViewModel.NumberOfRedRibbons
            };
        }

        public static ParticipantViewModel ParticipantToParticipantViewModel(Participant participant)
        {
            return new ParticipantViewModel
            {
                ParticipantId = participant.Id,
                FirstName = participant.FirstName,
                LastName = participant.LastName,
                Age = participant.Age,
                Gsm = participant.Gsm,
                Email = participant.Email,
                LicenseNumber = participant.LicenseNumber,
                DateTillLicenseIsValid = participant.DateTillLicenseIsValid,
                Grade = participant.Grade,
                NumberOfRedRibbons = participant.NumberOfRedRibbons
            };
        }
    }
}
