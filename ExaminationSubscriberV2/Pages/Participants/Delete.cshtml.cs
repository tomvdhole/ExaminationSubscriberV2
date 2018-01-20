using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExaminationSubscriberV2.Data;
using ExaminationSubscriberV2.Models;
using ExaminationSubscriberV2.Services;

namespace ExaminationSubscriberV2.Pages.Participants
{
    public class DeleteModel : PageModel
    {
        private readonly IParticipantService participantService;

        public DeleteModel(IParticipantService _participantService)
        {
            participantService = _participantService;
        }

        public Participant Participant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Participant = await participantService.GetAsync(new Participant { Id = (int) id });

            if (Participant == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Participant = await participantService.GetAsync(new Participant { Id = (int)id });

            if (Participant != null)
            {
                try { await participantService.DeleteAsync(Participant); } catch (DbUpdateConcurrencyException) { }
            }

            return RedirectToPage("./Index");
        }
    }
}
