using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExaminationSubscriberV2.Services;
using ExaminationSubscriberV2.Models;
using ExaminationSubscriberV2.ViewModels;
using ExaminationSubscriberV2.Helpers;

namespace ExaminationSubscriberV2.Pages.Participants
{
    public class IndexModel : PageModel
    {
        private readonly IParticipantService participantService;

        public IndexModel(IParticipantService _participantService)
        {
            participantService = _participantService;
        }

        public IList<ParticipantViewModel> ParticipantViewModels { get; set; }

        public async Task OnGetAsync()
        {
            ParticipantViewModels = new List<ParticipantViewModel>();
            List<Participant> participants = await participantService.GetAllParticipants();
            foreach(var participant in participants)
            {
                ParticipantViewModels.Add(Helper.ParticipantToParticipantViewModel(participant));
            }
        }
    }
}
