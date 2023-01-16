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
    public class IndexModel : PageModel
    {
        private readonly NoodleReviews.Data.NoodleReviewsContext _context;

        public IndexModel(NoodleReviews.Data.NoodleReviewsContext context)
        {
            _context = context;
        }

        public IList<NoodlePack> NoodlePack { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.NoodlePack != null)
            {
                NoodlePack = await _context.NoodlePack.ToListAsync();
            }
        }
    }
}
