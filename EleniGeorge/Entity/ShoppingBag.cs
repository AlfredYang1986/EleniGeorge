//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EleniGeorge.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class ShoppingBag
    {
        public ShoppingBag()
        {
            this.ShoppingBagRow = new HashSet<ShoppingBagRow>();
        }
    
        public int CustomerID { get; set; }
    
        public virtual ICollection<ShoppingBagRow> ShoppingBagRow { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}