using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Infrastructure.Security
{
    public class SqlConnectionHelper
    {
        public static string SqlConnectionString => "Server = (localdb)\\MSSQLLocalDB; Database = FocusDb; Trusted_Connection = True";
        //Server=.;Database=FocusDb;Trusted_Connection=True
    }
}
