using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskRazor.Models;

namespace MegaDesk.Pages.DeskQuotes
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesDeskQuoteContext _context;

        public DetailsModel(RazorPagesDeskQuoteContext context)
        {
            _context = context;
        }

      public DeskQuote DeskQuote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DeskQuote == null)
            {
                return NotFound();
            }

            var deskquote = await _context.DeskQuote.FirstOrDefaultAsync(m => m.DeskQuoteId == id);
            if (deskquote == null)
            {
                return NotFound();
            }
            else 
            {
                DeskQuote = deskquote;
            }
            return Page();
        }
    }
}
