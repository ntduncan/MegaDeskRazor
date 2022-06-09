using System;
using System.ComponentModel.DataAnnotations;

namespace MegaDeskRazor.Models
{
    public class RushOrder
    {
        [Required]
        public int RushOrderId { get; set; }
        [Required]
        public string Type { get; set;}
        [Required]
        [Display(Name = "Greater than 1000")]
        public decimal SmallDeskPrice { get; set; }
        [Required]
        [Display(Name = "1000 to 2000")]
        public decimal MediumDeskPrice { get; set; }
        [Required]
        [Display(Name = "Greater than 2000")]
        public decimal LargeDeskPrice { get; set; }
    }
}
