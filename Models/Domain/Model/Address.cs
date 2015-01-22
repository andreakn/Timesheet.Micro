using System.Collections.Generic;

namespace Timesheet.Micro.Models.Domain.Model
{
    public class Address : PersistentObject
    {
        public virtual Customer Customer { get; set; }
        public virtual AddressType AddressType { get; set; }
        public virtual string AddressText { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string City { get; set; }
        public virtual IList<Invoice> Invoices { get; set; }
        
        public virtual string FullAddress
        {
            get
            {
                string fullAddress = AddressText ?? "";
                fullAddress += (fullAddress.Length > 0 ? ", " : "") + PostalCode ?? "";
                fullAddress += (fullAddress.Length > 0 ? " " : "") + City ?? "";
                fullAddress += AddressType != null ? " (" + AddressType.Name + ")" : "";
                return fullAddress;
            }
        }
    }
}
