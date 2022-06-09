using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegaDeskRazor.Models;

    public class RazorPagesDeskQuoteContext : DbContext
    {
        public RazorPagesDeskQuoteContext (DbContextOptions<RazorPagesDeskQuoteContext> options)
            : base(options)
        {
        }

        public DbSet<MegaDeskRazor.Models.DeskQuote>? DeskQuote { get; set; }
        public DbSet<MegaDeskRazor.Models.RushOrder>? RushOrder { get; set; }
        public DbSet<MegaDeskRazor.Models.DesktopMaterial>? DesktopMaterial { get; set; }
        public DbSet<MegaDeskRazor.Models.Desk>? Desk { get; set; }
    }
