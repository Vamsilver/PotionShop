//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PotionShop.ADOApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sale
    {
        public int IdSale { get; set; }
        public int IdUser { get; set; }
        public int IdBuyerShop { get; set; }
        public int IdPotion { get; set; }
        public int IdStorage { get; set; }
        public int Count { get; set; }
        public int IdDiscount { get; set; }
        public int Cost { get; set; }
    
        public virtual Discount Discount { get; set; }
        public virtual Potion Potion { get; set; }
        public virtual Storage Storage { get; set; }
        public virtual User User { get; set; }
        public virtual BuyerShop BuyerShop { get; set; }
    }
}