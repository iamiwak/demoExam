//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Culteries.Base
{
    using System;
    using System.Collections.Generic;
    
    public partial class Manafactures
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Manafactures()
        {
            this.Product = new HashSet<Product>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
    
        public virtual Manafactures Manafactures1 { get; set; }
        public virtual Manafactures Manafactures2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }
    }
}