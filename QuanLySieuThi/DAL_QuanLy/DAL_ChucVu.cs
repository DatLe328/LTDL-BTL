using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_ChucVu : DBConnect
    {
        public DataSet GetChucVu()
        {
            DataSet ds = new DataSet();
            try
            {
                string sql = "SELECT * FROM ChucVu";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(ds);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return ds;
        }
        public bool AddChucVu(string maChucVu, string tenChucVu, string moTa)
        {
            try
            {
                string sql = "INSERT INTO ChucVu (MaChucVu, TenChucVu, MoTa) VALUES (@MaChucVu, @TenChucVu, @MoTa)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaChucVu", maChucVu);
                    cmd.Parameters.AddWithValue("@TenChucVu", tenChucVu);
                    cmd.Parameters.AddWithValue("@MoTa", moTa);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public bool UpdateChucVu(string maChucVu, string tenChucVu, string moTa)
        {
            try
            {
                string sql = "UPDATE ChucVu SET TenChucVu = @TenChucVu, MoTa = @MoTa WHERE MaChucVu = @MaChucVu";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaChucVu", maChucVu);
                    cmd.Parameters.AddWithValue("@TenChucVu", tenChucVu);
                    cmd.Parameters.AddWithValue("@MoTa", moTa);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public bool DeleteChucVu(string maChucVu)
        {
            try
            {
                string sql = "DELETE FROM ChucVu WHERE MaChucVu = @MaChucVu";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaChucVu", maChucVu);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return false;
        }
    }
}
