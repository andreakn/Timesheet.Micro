namespace Timesheet.Micro.Models.Domain.Model
{
    public class User : PersistentObject
    {
        public virtual string Username { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string PasswordSalt { get; set; }
    }
}
