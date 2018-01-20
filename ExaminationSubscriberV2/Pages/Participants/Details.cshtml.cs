using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExaminationSubscriberV2.Data;
using ExaminationSubscriberV2.Models;

namespace ExaminationSubscriberV2.Pages.Participants
{
    public class DetailsModel : PageModel
    {
        private readonly ExaminationSubscriberV2.Data.ExaminationSubscriberV2Context _context;

        public DetailsModel(ExaminationSubscriberV2.Data.ExaminationSubscriberV2Context context)
        {
            _context = context;
        }

        public Participant Participant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Participant = await _context.Participant
                .Include(p => p.Category).SingleOrDefaultAsync(m => m.Id == id);

            if (Participant == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
