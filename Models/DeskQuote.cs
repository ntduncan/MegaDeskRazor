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
        public int RushOrderId { get; set; }

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
        public decimal GetQuotePrice(RazorPagesDeskQuoteContext context)
        { 
            decimal surfaceArea = this.Desk.Width * this.Desk.Depth;
            decimal drawerCost = this.Desk.NumberOfDrawers * DRAWER_COST;

            //Determine Surface Area Cost
            decimal surfacePrice = 0.00M;
            if(surfaceArea > 1000) { 
                surfacePrice = (surfaceArea - 1000) * SURFACE_AREA_COST;
            }
            
            //Determine Surface Material Cost
            decimal surfaceMaterialCost = 0.00M;
            var surfaceAreaPrices = context.DesktopMaterial
            .Where(d => d.DesktopMaterialId == this.Desk.DesktopMaterialId)
            .FirstOrDefault();
            surfaceMaterialCost = surfaceAreaPrices.Cost;

            //Determine Shipping Cost
            decimal shippingPrice = 0.00M;
            var shippingPrices = context.RushOrder
            .Where(d => d.RushOrderId == this.RushOrderId)
            .FirstOrDefault();
            if(surfaceArea < 1000){ 
                shippingPrice = shippingPrices.SmallDeskPrice;
            } else if (surfaceArea >= 1000 || surfaceArea <= 200){ 
                shippingPrice = shippingPrices.MediumDeskPrice;   
            } else { 
                shippingPrice = shippingPrices.LargeDeskPrice;
            }
        

            this.QuotePrice = surfacePrice + surfaceMaterialCost + drawerCost + BASE_DESK_PRICE;
        
            return this.QuotePrice;
        }
    }
}
