using System;
using System.ComponentModel.DataAnnotations;

namespace MegaDeskRazor.Models
{
    public class DesktopMaterial
    {
        [Required]
        public int DesktopMaterialId { get; set; }
        [Required]
        public string Material { get; set; } = string.Empty;
        [Required]
        public decimal Cost { get; set; }
    }
}
