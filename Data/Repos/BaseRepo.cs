using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Timesheet.Micro.Data.Repos
{
    public class BaseRepo
    {
        protected SqlConnection GetConn()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["TimesheetDB"].ConnectionString);
        }
    }
}