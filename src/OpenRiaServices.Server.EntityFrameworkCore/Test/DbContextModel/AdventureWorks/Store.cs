//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DbContextModels.AdventureWorks
{
    using System;
    using System.Collections.Generic;
    
    public partial class Store
    {
        public Store()
        {
            this.StoreContacts = new HashSet<StoreContact>();
        }
    
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public Nullable<int> SalesPersonID { get; set; }
        public string Demographics { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual SalesPerson SalesPerson { get; set; }
        public virtual ICollection<StoreContact> StoreContacts { get; set; }
    }
}
