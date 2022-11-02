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
    
    public partial class Potion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Potion()
        {
            this.PotionKeeping = new HashSet<PotionKeeping>();
            this.Sale = new HashSet<Sale>();
            this.ConsumablesUsing = new HashSet<ConsumablesUsing>();
        }
    
        public int IdPotion { get; set; }
        public int IdType { get; set; }
        public string Name { get; set; }
    
        public virtual PotionType PotionType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PotionKeeping> PotionKeeping { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sale { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsumablesUsing> ConsumablesUsing { get; set; }
    }
}
