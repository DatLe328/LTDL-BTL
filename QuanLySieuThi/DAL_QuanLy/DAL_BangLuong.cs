using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_BangLuong : DBConnect
    {
        public DataTable GetBangLuong()
        {
            DataTable ds = new DataTable();
            try
            {
                string sql = "SELECT * FROM BangLuong";
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
        public DataTable GetBangLuong(int maNhanVien)
        {
            DataTable ds = new DataTable();
            try
            {
                string sql = "SELECT * FROM BangLuong WHERE MaNhanVien = @MaNhanVien";
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
        public DataTable GetBangLuong(int maNhanVien, int thang, int nam)
        {
            DataTable ds = new DataTable();
            try
            {
                string sql = "SELECT * FROM BangLuong WHERE MaNhanVien = @MaNhanVien AND Thang = @Thang AND Nam = @Nam";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    cmd.Parameters.AddWithValue("@Thang", thang);
                    cmd.Parameters.AddWithValue("@Nam", nam);
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
        public int GetLastMaLuong()
        {
            int lastMaLuong = 0;
            try
            {
                string sql = "SELECT MAX(MaLuong) FROM BangLuong";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        lastMaLuong = Convert.ToInt32(result);
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
            return lastMaLuong;
        }
        public bool AddBangLuong(int maNhanVien, int thang, int nam, int tongLuong, string trangThai)
        {
            try
            {
                string sql = "INSERT INTO BangLuong (MaNhanVien, Thang, Nam, TongLuong, TrangThai) VALUES (@MaNhanVien, @Thang, @Nam, @TongLuong, @TrangThai)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    cmd.Parameters.AddWithValue("@Thang", thang);
                    cmd.Parameters.AddWithValue("@Nam", nam);
                    cmd.Parameters.AddWithValue("@TongLuong", tongLuong);
                    cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding BangLuong: " + ex.Message);
                return false;
            }
        }
        public bool UpdateBangLuong(int maLuong, int soNgayCong, DateTime ngayChotLuong, string trangThai)
        {
            try
            {
                string sql = "UPDATE BangLuong SET SoNgayCong = @SoNgayCong, NgayChotLuong = @NgayChotLuong, TrangThai = @TrangThai WHERE MaLuong = @MaLuong";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaLuong", maLuong);
                    cmd.Parameters.AddWithValue("@SoNgayCong", soNgayCong);
                    cmd.Parameters.AddWithValue("@NgayChotLuong", ngayChotLuong);
                    cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating BangLuong: " + ex.Message);
                return false;
            }
        }
    }
}
