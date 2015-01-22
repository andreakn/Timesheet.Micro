using System.Collections.Generic;
using System.Linq;
using Dapper;
using Timesheet.Micro.Models.Domain.Model;

namespace Timesheet.Micro.Data.Repos
{
    public class UserRepository: BaseRepo, IUserRepository
    {
        public string GetCurrentUser()
        {
            return "Andreas";
        }

        public IEnumerable<User> GetAll()
        {
            using (var conn = GetConn())
            {
                return conn.Query<User>("select * from Users");
            }
        }

        public User GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Save(User entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new System.NotImplementedException();
        }

        public User GetByUserName(string username)
        {
            using (var conn = GetConn())
            {
                return conn.Query<User>("select * from Users where Username = @username", new {username}).Single();
            }
        }

        public void Save(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public bool UsernameExists(string username)
        {
            using (var conn = GetConn())
            {
                return conn.ExecuteScalar<int>("select count(*) from Users where Username = @username", new {username})>0;
            }
        }

        public void Create(User user)
        {
            using (var conn = GetConn())
            {
                conn.Execute(@"Insert into Users 
                            ( Username,  PasswordHash,  PasswordSalt) values 
                            (@Username, @PasswordHash, @PasswordSalt)", new { user.Username, user.PasswordHash, user.PasswordSalt });
            }
        }
    }
}