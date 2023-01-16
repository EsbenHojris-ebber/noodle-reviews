using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NoodleReviews.Data;
using NoodleReviews.Models;

namespace NoodleReviews.Pages.NoodlePacks
{
    public class EditModel : PageModel
    {
        private readonly NoodleReviews.Data.NoodleReviewsContext _context;

        public EditModel(NoodleReviews.Data.NoodleReviewsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public NoodlePack NoodlePack { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.NoodlePack == null)
            {
                return NotFound();
            }

            var noodlepack =  await _context.NoodlePack.FirstOrDefaultAsync(m => m.Id == id);
            if (noodlepack == null)
            {
                return NotFound();
            }
            NoodlePack = noodlepack;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(NoodlePack).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoodlePackExists(NoodlePack.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NoodlePackExists(int id)
        {
          return (_context.NoodlePack?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
