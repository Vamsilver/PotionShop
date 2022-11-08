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
    
    public partial class Storage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Storage()
        {
            this.ConsumableKeeping = new HashSet<ConsumableKeeping>();
            this.PotionKeeping = new HashSet<PotionKeeping>();
            this.Sale = new HashSet<Sale>();
        }
    
        public int IdStorage { get; set; }
        public string Address { get; set; }
        public int IdTypeStorage { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsumableKeeping> ConsumableKeeping { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PotionKeeping> PotionKeeping { get; set; }
        public virtual TypeStorage TypeStorage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sale { get; set; }

        public override string ToString()
        {
            return Address;
        }
    }
}
