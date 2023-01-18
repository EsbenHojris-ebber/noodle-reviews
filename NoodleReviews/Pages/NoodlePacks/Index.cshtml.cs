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
    public class IndexModel : PageModel
    {
        private readonly NoodleReviews.Data.NoodleReviewsContext _context;

        public IndexModel(NoodleReviews.Data.NoodleReviewsContext context)
        {
            _context = context;
        }

        public IList<NoodlePack> NoodlePack { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Grades { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? NoodlePackGrade { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.NoodlePack != null)
            {
                IQueryable<Grade> gradeQuery = from np in _context.NoodlePack
                                               orderby np.Grade
                                               select np.Grade;

                var noodlePacks = from np in _context.NoodlePack
                                  select np;

                if (!string.IsNullOrEmpty(SearchString))
                {
                    noodlePacks = noodlePacks.Where(s => s.Name.Contains(SearchString));
                }

                if (Enum.TryParse<Grade>(NoodlePackGrade, true, out var res))
                {
                    noodlePacks = noodlePacks.Where(x => x.Grade == res);
                }
                Grades = new SelectList(await gradeQuery.Distinct().ToListAsync());
                NoodlePack = await noodlePacks.ToListAsync();
            }
        }
    }
}
