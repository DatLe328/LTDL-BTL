using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_TaiKhoan : DBConnect
    {
        public bool Authenticate(string username, string password)
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM TaiKhoan WHERE TenDangNhap = @username AND MatKhau = @password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                
                SqlDataReader reader = cmd.ExecuteReader();
                bool isAuthorized = reader.HasRows;
                reader.Close();
                return isAuthorized;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public int GetMaNhanVienByTenDangNhap(string username)
        {
            try
            {
                conn.Open();
                string query = "SELECT MaTaiKhoan FROM TaiKhoan WHERE TenDangNhap = @username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
