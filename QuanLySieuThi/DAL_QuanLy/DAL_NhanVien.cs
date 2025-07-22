using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_NhanVien : DBConnect
    {
        public DataTable GetNhanVien()
        {
            DataTable ds = new DataTable();
            try
            {
                string sql = "SELECT * FROM NhanVien";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
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
        public DataTable GetNhanVien(int maNhanVien)
        {
            DataTable ds = new DataTable();
            try
            {
                string sql = "SELECT * FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
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
        public DTO_ChucVu GetChucVu(int maNhanVien)
        {
            try
            {
                string sql = "SELECT ChucVu.* FROM NhanVien " +
                             "JOIN ChucVu ON NhanVien.MaChucVu = ChucVu.MaChucVu " +
                             "WHERE NhanVien.MaNhanVien = @MaNhanVien";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable ds = new DataTable();
                        adapter.Fill(ds);
                        DTO_ChucVu chucVu = new DTO_ChucVu();
                        if (ds.Rows.Count > 0)
                        {
                            DataRow row = ds.Rows[0];
                            chucVu.MaChucVu = Convert.ToInt32(row["MaChucVu"]);
                            chucVu.TenChucVu = row["TenChucVu"].ToString();
                            chucVu.MucLuong = Convert.ToInt32(row["MucLuong"].ToString());
                        }
                        return chucVu;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public int GetLastMaNhanVien()
        {
            try
            {
                string sql = "SELECT MAX(MaNhanVien) FROM NhanVien";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return -1;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public bool AddNhanVien(string hoTenNV, string soDienThoai, string email, DateTime ngaySinh, int maChucVu)
        {
            try
            {
                string sql = "INSERT INTO NhanVien (HoTenNV, SoDienThoai, Email, NgaySinh, MaChucVu) " +
                             "VALUES (@HoTenNV, @SoDienThoai, @Email, @NgaySinh, @MaChucVu)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@HoTenNV", hoTenNV);
                    cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    cmd.Parameters.AddWithValue("@MaChucVu", maChucVu);
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
        public bool UpdateNhanVien(int maNhanVien, string hoTenNV, string soDienThoai, string email, DateTime ngaySinh, int maChucVu)
        {
            try
            {
                string sql = "UPDATE NhanVien SET HoTenNV = @HoTenNV, SoDienThoai = @SoDienThoai, " +
                             "Email = @Email, NgaySinh = @NgaySinh, MaChucVu = @MaChucVu WHERE MaNhanVien = @MaNhanVien";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    cmd.Parameters.AddWithValue("@HoTenNV", hoTenNV);
                    cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    cmd.Parameters.AddWithValue("@MaChucVu", maChucVu);
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
        public bool DeleteNhanVien(int maNhanVien)
        {
            try
            {
                string sql = "DELETE FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
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
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
