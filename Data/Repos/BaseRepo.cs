using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using Timesheet.Micro.Models.Domain.Model;

namespace Timesheet.Micro.Data.Repos
{
    public abstract class BaseRepo<T>: IRepository<T> where T:PersistentObject
    {
        protected virtual string TableName
        {
            get { return this.GetType().Name.Replace("Repository", "s"); }
        }

        protected SqlConnection GetConn()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDB"].ConnectionString);
        }

        public IEnumerable<T> GetAll()
        {
            using (var conn = GetConn())
            {
                return conn.Query<T>("select * from "+TableName);
            }
        }

        public T GetById(int id)
        {
            using (var conn = GetConn())
            {
                return conn.Query<T>(string.Format("select * from {0} where id = @id", TableName),new{id}).Single();
            }
        }

        public void Save(T entity)
        {
            using (var conn = GetConn())
            {
                if (entity.IsPersistent)
                {
                    conn.Execute( string.Format("update {0} ({1}) VALUES ({2}) where Id = @Id",TableName, GetColNames(entity), GetParams(entity)), entity);
                }
                else
                {
                    conn.Execute(string.Format("insert into {0} ({1}) VALUES ({2})", TableName, GetColNames(entity), GetParams(entity)), entity);
                }
            }
        }

        private string GetParams(T entity)
        {
            var list = entity.FieldsToSave().OrderBy(s => s).Select(s=>"@"+s);
            return string.Join(", ", list);
        }

        private string GetColNames(T entity)
        {
            var list = entity.FieldsToSave().OrderBy(s=>s);
            return string.Join(", ", list);
        }

        public void Delete(T entity)
        {
            using (var conn = GetConn())
            {
                conn.Execute(string.Format("delete from {0} where id = @Id", TableName), new { entity.Id });
            }
        }
    }
}