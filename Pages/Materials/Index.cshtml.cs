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
    public class IndexModel : PageModel
    {
        private readonly MegaDeskContext _context;

        public IndexModel(MegaDeskContext context)
        {
            _context = context;
        }

        public IList<DesktopMaterial> DesktopMaterial { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.DesktopMaterial != null)
            {
                DesktopMaterial = await _context.DesktopMaterial.ToListAsync();
            }
        }
    }
}
