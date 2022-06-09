using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaDeskRazor.Models
{
    public class DeskQuote
    {

        //Constants
        private const decimal BASE_DESK_PRICE = 200.00M;
        private const decimal SURFACE_AREA_COST = 1.00M;
        private const decimal DRAWER_COST = 50.00M;

        //Properties
        public int DeskQuoteId { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Customer Name")]
        [Required]
        public string CustomerName { get; set; }
        
        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime QuoteDate { get; set; }
        
        [Display(Name = "Shipping Option")]
        public int DeliveryTypeId { get; set; }

        [Required]
        public int DeskId { get; set; }
        
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Quote Price")]
        public decimal QuotePrice { get; set; }

        //Nav properties
        public Desk Desk { get; set; }  
        public RushOrder RushOrder { get; set; }


        // //Methods
        // public decimal GetQuotePrice(MegaDeskRazorContext context)
        // { 
        //     decimal quotePrice = BASE_DESK_PRICE;
        //     decimal surfaceArea = this.Desk.Width * this.Desk.Depth;

            // var surfaceAreaPrices = context.DesktopMaterial
            // .Where(d => d.DesktopMaterialId == this.Desk.DesktopMaterialId)
            // .FirstOrDefault();

            // decimal desktopMaterialCost = surfaceAreaPrices.Cost;

        //     decimal drawerCost = this.Desk.NumberOfDrawers * DRAWER_COST;

        //     //TODO: Figure out rush order pricing
        

        //     quotePrice += (surfaceArea + desktopMaterialCost + drawerCost);
        //     this.QuotePrice = quotePrice;

        //     return this.QuotePrice;
        // }
    }
}
