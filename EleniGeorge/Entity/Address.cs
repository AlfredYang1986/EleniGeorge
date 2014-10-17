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
    
    public partial class Address
    {
        public Address()
        {
            this.Customer = new HashSet<Customer>();
            this.SalesOrderHeader = new HashSet<SalesOrderHeader>();
            this.SalesOrderHeader1 = new HashSet<SalesOrderHeader>();
        }
    
        public int AddressID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int StateProvinceID { get; set; }
        public string PostalCode { get; set; }
        public System.Data.Spatial.DbGeography SpatialLocation { get; set; }
        public System.Guid AddressGUID { get; set; }
    
        public virtual StateProvince StateProvince { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }
        public virtual ICollection<SalesOrderHeader> SalesOrderHeader1 { get; set; }
    }
}
