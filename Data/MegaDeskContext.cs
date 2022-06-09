using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegaDeskRazor.Models;

    public class MegaDeskContext : DbContext
    {
        public MegaDeskContext (DbContextOptions<MegaDeskContext> options)
            : base(options)
        {
        }

        public DbSet<MegaDeskRazor.Models.DesktopMaterial>? DesktopMaterial { get; set; }
    }
