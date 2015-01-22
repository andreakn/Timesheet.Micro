using Timesheet.Micro.Models.Domain.Model;

namespace Timesheet.Micro.Data.Repos
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUserName(string username);
        void Save(string username, string password);
    }
}