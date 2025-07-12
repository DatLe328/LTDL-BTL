using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
            string currentDir = Environment.CurrentDirectory;
            var lines = File.ReadAllLines(currentDir + "/../../../DAL_QuanLy/.env");
            var dict = new Dictionary<string, string>();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#")) continue;
                var parts = line.Split('=');
                if (parts.Length == 2)
                    dict[parts[0].Trim()] = parts[1].Trim();
            }
            Console.WriteLine(dict["DB_SERVER"]);
            Console.WriteLine(dict["DB_DATABASE"]);
            // fallback
            string server = dict.ContainsKey("DB_SERVER") ? dict["DB_SERVER"] : "(localdb)\\localhost";
            string database = dict.ContainsKey("DB_DATABASE") ? dict["DB_DATABASE"] : "QLST";
            string user = dict.ContainsKey("DB_USER") ? dict["DB_USER"] : null;
            string pass = dict.ContainsKey("DB_PASS") ? dict["DB_PASS"] : null;

            string connStr = user == null
                ? $"Server={server};Database={database};Integrated Security=True;TrustServerCertificate=True;"
                : $"Server={server};Database={database};User Id={user};Password={pass};TrustServerCertificate=True;";

            conn = new SqlConnection(connStr);
        }
    }
}
