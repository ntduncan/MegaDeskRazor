using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MegaDeskRazor.Models
{
    public class Desk
    {
        public int DeskId { get; set; }
        [Required]
        [Range(24,96)]
        public decimal Width { get; set; }
        [Required]
        [Range(12,48)]
        public decimal Depth { get; set; }
        [Required]
        [Display(Name = "Drawers")]
        [Range(0,7)]
        public int NumberOfDrawers { get; set; }
        [Required]
        public int DesktopMaterialId { get; set; }
        [Display(Name = "Desktop Material")]
        public DesktopMaterial DesktopMaterial { get; set; }
  }
}
