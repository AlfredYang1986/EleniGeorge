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
    
    public partial class Item
    {
        public Item()
        {
            this.ItemPicture = new HashSet<ItemPicture>();
            this.ItemSize = new HashSet<ItemSize>();
            this.SalesOrderRow = new HashSet<SalesOrderRow>();
            this.Customer = new HashSet<Customer>();
            this.Color = new HashSet<Color>();
            this.Material = new HashSet<Material>();
            this.Occasion = new HashSet<Occasion>();
            this.Style = new HashSet<Style>();
            this.Customer1 = new HashSet<Customer>();
        }
    
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public Nullable<short> LowStockWarningLevel { get; set; }
        public Nullable<double> ListPrice { get; set; }
        public Nullable<double> StandardCost { get; set; }
        public string ItemDesc { get; set; }
        public Nullable<int> DaysToMake { get; set; }
        public System.DateTime SellStartDate { get; set; }
        public Nullable<System.DateTime> SellEndDate { get; set; }
        public int CategoryID { get; set; }
        public string Gender { get; set; }
        public int ItemGUID { get; set; }
    
        public virtual ICollection<ItemPicture> ItemPicture { get; set; }
        public virtual ICollection<ItemSize> ItemSize { get; set; }
        public virtual ICollection<SalesOrderRow> SalesOrderRow { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Color> Color { get; set; }
        public virtual ICollection<Material> Material { get; set; }
        public virtual ICollection<Occasion> Occasion { get; set; }
        public virtual ICollection<Style> Style { get; set; }
        public virtual ICollection<Customer> Customer1 { get; set; }
    }
}