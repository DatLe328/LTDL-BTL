using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DBConnect
    {
        protected SqlConnection conn;
        public DBConnect()
        {
            conn = new SqlConnection("Server=(localdb)\\localDB1;Database=QLST;Integrated Security=True;TrustServerCertificate=True;");
        }
    }
}
