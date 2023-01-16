using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NoodleReviews.Data;
using NoodleReviews.Models;

namespace NoodleReviews.Pages.NoodlePacks
{
    public class DetailsModel : PageModel
    {
        private readonly NoodleReviews.Data.NoodleReviewsContext _context;

        public DetailsModel(NoodleReviews.Data.NoodleReviewsContext context)
        {
            _context = context;
        }

      public NoodlePack NoodlePack { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.NoodlePack == null)
            {
                return NotFound();
            }

            var noodlepack = await _context.NoodlePack.FirstOrDefaultAsync(m => m.Id == id);
            if (noodlepack == null)
            {
                return NotFound();
            }
            else 
            {
                NoodlePack = noodlepack;
            }
            return Page();
        }
    }
}
