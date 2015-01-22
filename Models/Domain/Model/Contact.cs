using System.Collections.Generic;

namespace Timesheet.Micro.Models.Domain.Model
{
    public class Contact : PersistentObject
    {
        public virtual Customer Customer { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Email { get; set; }
        public virtual string Role { get; set; }
        public virtual IList<Invoice> Invoices { get; set; }

        public virtual string FullName
        {
            get
            {
                if (FirstName == null && LastName == null)
                    return string.Empty;
                if (FirstName == null)
                    return LastName;
                if (LastName == null)
                    return FirstName;
                return FirstName + " " + LastName;
            }
        }
    }
}
