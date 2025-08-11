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
        public string getPhanQuyenByTenDangNhap(string tenDangNhap)
        {
            try
            {
                conn.Open();
                string query = "SELECT PhanQuyen FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return string.Empty;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool AddTaiKhoan(string tenDangNhap = "", string matKhau = "123456", int maNhanVien = 0)
        {
            if (string.IsNullOrEmpty(tenDangNhap) || maNhanVien == 0)
            {
                Console.WriteLine("Tên đăng nhập và mã nhân viên không được để trống.");
                return false;
            }
            try
            {
                string sql = "INSERT INTO TaiKhoan (TenDangNhap, MatKhau, MaNhanVien) VALUES (@TenDangNhap, @MatKhau, @MaNhanVien)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);

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
                conn.Close();
            }
        }
        public bool CheckUsernameExists(string tenDangNhap)
        {
            try
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
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
        public bool UpdateTaiKhoan(int maTaiKhoan, string tenDangNhap, string matKhau, int maNhanVien)
        {
            try
            {
                string sql = "UPDATE TaiKhoan SET TenDangNhap = @TenDangNhap, MatKhau = @MatKhau, MaNhanVien = @MaNhanVien WHERE MaTaiKhoan = @MaTaiKhoan";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
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
                conn.Close();
            }
        }
        public bool DeleteTaiKhoanByUserName(int tenDangNhap)
        {
            string sql = "DELETE FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
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
                conn.Close();
            }
        }

    }
}
