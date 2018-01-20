using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExaminationSubscriberV2.Data;
using ExaminationSubscriberV2.Models;
using ExaminationSubscriberV2.ViewModels;
using ExaminationSubscriberV2.Helpers;
using ExaminationSubscriberV2.Services;

namespace ExaminationSubscriberV2.Pages.Participants
{
    public class EditModel : PageModel
    {
        private readonly IParticipantService participantService;

        public EditModel(IParticipantService _participantService)
        {
            participantService = _participantService;
        }

        [BindProperty]
        public ParticipantViewModel ParticipantViewModel { get; set; } = new ParticipantViewModel();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Participant participant = await participantService.GetAsync(new Participant { Id = (int) id });

            if (participant == null)
            {
                return NotFound();
            }

            ParticipantViewModel = Helper.ParticipantToParticipantViewModel(participant);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync([FromServices] ISubscribeService subscribeService)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Participant participant = Helper.ParticipantViewModelToParticipant(ParticipantViewModel);
            try{ await subscribeService.UpdateSubscription(participant); } catch (DbUpdateConcurrencyException){}
            return RedirectToPage("./Index");
        }
    }
}
