using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskRazor.Models;

namespace MegaDesk.Pages.DeskQuotes
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesDeskQuoteContext _context;

        public CreateModel(RazorPagesDeskQuoteContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Desk Desk { get; set; }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        public IActionResult OnGet()
        {
            // ViewData["DeskQuoteId"] = new SelectList(_context.Set<DeskQuote>(), "DeskQuoteId", "DeskQuoteId");
            // ViewData["DeskId"] = new SelectList(_context.Set<Desk>(), "DeskId", "DeskId");
            ViewData["RushOrderId"] = new SelectList(_context.RushOrder, "RushOrderId", "Type");
            ViewData["DesktopMaterialId"] = new SelectList(_context.DesktopMaterial, "DesktopMaterialId", "Material");
            return Page();
        }      
        
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }
            // _context.DesktopMaterial.Add(DesktopMaterial);
            // _context.RushOrder.Add(RushOrder);
            DeskQuote.QuotePrice = DeskQuote.GetQuotePrice(_context);
            DeskQuote.DeskId = Desk.DeskId;
            
            _context.Desk.Add(Desk);
            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
