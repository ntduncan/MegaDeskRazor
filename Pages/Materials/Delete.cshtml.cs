using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskRazor.Models;

namespace MegaDesk.Pages.Materials
{
    public class DeleteModel : PageModel
    {
        private readonly MegaDeskContext _context;

        public DeleteModel(MegaDeskContext context)
        {
            _context = context;
        }

        [BindProperty]
      public DesktopMaterial DesktopMaterial { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DesktopMaterial == null)
            {
                return NotFound();
            }

            var desktopmaterial = await _context.DesktopMaterial.FirstOrDefaultAsync(m => m.DesktopMaterialId == id);

            if (desktopmaterial == null)
            {
                return NotFound();
            }
            else 
            {
                DesktopMaterial = desktopmaterial;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.DesktopMaterial == null)
            {
                return NotFound();
            }
            var desktopmaterial = await _context.DesktopMaterial.FindAsync(id);

            if (desktopmaterial != null)
            {
                DesktopMaterial = desktopmaterial;
                _context.DesktopMaterial.Remove(DesktopMaterial);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
