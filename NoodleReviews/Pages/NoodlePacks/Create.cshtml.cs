using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NoodleReviews.Data;
using NoodleReviews.Models;

namespace NoodleReviews.Pages.NoodlePacks
{
    public class CreateModel : PageModel
    {
        private readonly NoodleReviews.Data.NoodleReviewsContext _context;

        public CreateModel(NoodleReviews.Data.NoodleReviewsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public NoodlePack NoodlePack { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.NoodlePack == null || NoodlePack == null)
            {
                return Page();
            }

            _context.NoodlePack.Add(NoodlePack);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
