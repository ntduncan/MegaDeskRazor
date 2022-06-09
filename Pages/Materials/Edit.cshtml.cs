using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegaDeskRazor.Models;

namespace MegaDesk.Pages.Materials
{
    public class EditModel : PageModel
    {
        private readonly MegaDeskContext _context;

        public EditModel(MegaDeskContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DesktopMaterial DesktopMaterial { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DesktopMaterial == null)
            {
                return NotFound();
            }

            var desktopmaterial =  await _context.DesktopMaterial.FirstOrDefaultAsync(m => m.DesktopMaterialId == id);
            if (desktopmaterial == null)
            {
                return NotFound();
            }
            DesktopMaterial = desktopmaterial;
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

            _context.Attach(DesktopMaterial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesktopMaterialExists(DesktopMaterial.DesktopMaterialId))
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

        private bool DesktopMaterialExists(int id)
        {
          return _context.DesktopMaterial.Any(e => e.DesktopMaterialId == id);
        }
    }
}
