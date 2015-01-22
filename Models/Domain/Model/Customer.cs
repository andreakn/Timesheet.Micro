using System.Collections.Generic;

namespace Timesheet.Micro.Models.Domain.Model
{
    public class Customer : AuditedPersistentObject
    {
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Description { get; set; }
        public virtual Employee CustomerContact { get; set; }
        public virtual IList<Address> Addresses { get; set; }
        public virtual IList<Contact> Contacts { get; set; }
        public virtual IList<Invoice> Invoices { get; set; }
        public virtual IList<Project> Projects { get; set; }

        public static Customer Dummy()
        {
                return new Customer
                    {
                        Addresses = new List<Address>(),
                        Code = "ukjent",
                        Contacts = new List<Contact>(),
                        CreatedBy = Employee.Dummy(),
                        CustomerContact = Employee.Dummy(),
                        Description = "ukjent",
                        Invoices = new List<Invoice>(),
                        Projects = new List<Project>(),
                        Name = "ukjent"
                    };
        }
    }
}
