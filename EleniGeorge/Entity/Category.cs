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
    
    public partial class Category
    {
        public Category()
        {
            this.Item = new HashSet<Item>();
            this.Category11 = new HashSet<Category>();
            this.Category2 = new HashSet<Category>();
        }
    
        public int CategoryID { get; set; }
        public string Category1 { get; set; }
    
        public virtual ICollection<Item> Item { get; set; }
        public virtual ICollection<Category> Category11 { get; set; }
        public virtual ICollection<Category> Category2 { get; set; }
    }
}
