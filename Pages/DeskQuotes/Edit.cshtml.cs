using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegaDeskRazor.Models;

namespace MegaDesk.Pages.DeskQuotes
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesDeskQuoteContext _context;

        public EditModel(RazorPagesDeskQuoteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) { return NotFound(); }

            // DeskQuote = await _context.DeskQuote;
            DeskQuote = await _context.DeskQuote
                .Include(d => d.RushOrder)
                .Include(d => d.Desk)
                .FirstOrDefaultAsync(n => n.DeskQuoteId == id);

            if (DeskQuote == null) { return NotFound(); }
            ViewData["RushOrderId"] = new SelectList(_context.RushOrder, "RushOrderId", "Type");
            ViewData["DesktopMaterialId"] = new SelectList(_context.DesktopMaterial, "DesktopMaterialId", "Material");

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

                _context.Attach(DeskQuote.Desk).State = EntityState.Modified;


                try
                {
                    //Save Desk
                    await _context.SaveChangesAsync();

                    // Reset Quote Price
                    DeskQuote.QuotePrice = DeskQuote.GetQuotePrice(_context);

                    //Save DeskQuote
                    _context.Attach(DeskQuote).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!DeskQuoteExists(DeskQuote.DeskQuoteId))
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

        private bool DeskQuoteExists(int id)
        {
          return _context.DeskQuote.Any(e => e.DeskQuoteId == id);
        }
    }
}
