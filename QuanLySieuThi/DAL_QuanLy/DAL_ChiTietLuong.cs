using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL_QuanLy
{
    public class DAL_ChiTietLuong : DBConnect
    {
        public bool AddChiTietLuong(int maLuong, string loaiKhoan, int Sotien, string ghiChu)
        {
            try
            {
                string sql = "INSERT INTO ChiTietLuong (MaLuong, LoaiKhoan, SoTien, GhiChu) VALUES (@MaLuong, @LoaiKhoan, @SoTien, @GhiChu)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaLuong", maLuong);
                    cmd.Parameters.AddWithValue("@LoaiKhoan", loaiKhoan);
                    cmd.Parameters.AddWithValue("@SoTien", Sotien);
                    cmd.Parameters.AddWithValue("@GhiChu", ghiChu);
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding ChiTietLuong: " + ex.Message);
                return false;
            }
        }
        public DataTable GetChiTietLuong(int maLuong)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM ChiTietLuong WHERE MaLuong = @MaLuong";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaLuong", maLuong);
                    conn.Open();
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                    conn.Close();
                }
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving ChiTietLuong: " + ex.Message);
                return null;
            }
        }
        public int GetTongTienLuong(int maLuong)
        {
            try
            {
                string sql = "SELECT SUM(SoTien) FROM ChiTietLuong WHERE MaLuong = @MaLuong";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaLuong", maLuong);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    conn.Close();
                    return result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error calculating total salary: " + ex.Message);
                return 0;
            }
        }
        public bool DeleteChiTietLuong(int maChiTietLuong)
        {
            try
            {
                string sql = "DELETE FROM ChiTietLuong WHERE MaChiTietLuong = @MaChiTietLuong";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaChiTietLuong", maChiTietLuong);
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting ChiTietLuong: " + ex.Message);
                return false;
            }
        }
        public bool UpdateChiTietLuong(int maChiTietLuong, string loaiKhoan, int soTien, string ghiChu)
        {
            try
            {
                string sql = "UPDATE ChiTietLuong SET LoaiKhoan = @LoaiKhoan, SoTien = @SoTien, GhiChu = @GhiChu WHERE MaChiTietLuong = @MaChiTietLuong";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaChiTietLuong", maChiTietLuong);
                    cmd.Parameters.AddWithValue("@LoaiKhoan", loaiKhoan);
                    cmd.Parameters.AddWithValue("@SoTien", soTien);
                    cmd.Parameters.AddWithValue("@GhiChu", ghiChu);
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating ChiTietLuong: " + ex.Message);
                return false;
            }
        }

        //Bao cao thong ke
        public DataTable ThongKeTatCaLuongTheoLoaiKhoan()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = @"SELECT LoaiKhoan, SUM(SoTien) AS TongTien
                       FROM ChiTietLuong
                       GROUP BY LoaiKhoan";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thống kê: " + ex.Message);
            }
            return dt;
        }
        public DataTable GetTop5NhanVienLuongCaoNhat()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = @"
                    SELECT TOP 5 nv.HoTenNV, SUM(ct.SoTien) AS TongLuong
                    FROM ChiTietLuong ct
                    JOIN BangLuong bl ON ct.MaLuong = bl.MaLuong
                    JOIN NhanVien nv ON bl.MaNhanVien = nv.MaNhanVien
                    GROUP BY nv.HoTenNV
                    ORDER BY TongLuong DESC";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thống kê top 5 lương: " + ex.Message);
            }
            return dt;
        }
    }
}
