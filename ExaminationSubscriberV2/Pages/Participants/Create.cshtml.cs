using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExaminationSubscriberV2.Data;
using ExaminationSubscriberV2.Models;
using ExaminationSubscriberV2.Services;
using ExaminationSubscriberV2.ViewModels;
using ExaminationSubscriberV2.Helpers;

namespace ExaminationSubscriberV2.Pages.Participants
{
    public class CreateModel : PageModel
    {
        private readonly ISubscribeService subscribeService;

        public CreateModel(ISubscribeService _subscribeService)
        {
            subscribeService = _subscribeService;
        }

        public IActionResult OnGet()
        {        
            return Page();            
        }

        [BindProperty]
        public ParticipantViewModel ParticipantViewModel { get; set; } = new ParticipantViewModel();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Participant participant = Helper.ParticipantViewModelToParticipant(ParticipantViewModel);
            await subscribeService.Subscribe(participant);

            return RedirectToPage("./Index");
        }
    }
}