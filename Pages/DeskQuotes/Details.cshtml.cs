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

            DeskQuote = await _context.DeskQuote
                .Include(d => d.RushOrder)
                .Include(d => d.Desk)
                .Include(d => d.Desk.DesktopMaterial)
                .FirstOrDefaultAsync(n => n.DeskQuoteId == id);

            // ViewData["RushOrderId"] = new SelectList(_context.RushOrder, "RushOrderId", "Type");
            // ViewData["DesktopMaterialId"] = new SelectList(_context.DesktopMaterial, "DesktopMaterialId", "Material");

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