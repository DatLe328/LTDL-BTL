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
    public class DAL_LoHang : DBConnect
    {
        public DataTable GetLoHang()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM LoHang";
                using (var cmd = new SqlCommand(sql, conn))
                {
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
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
        public DataTable GetLoHang(int maKho)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM LoHang WHERE MaKho = @MaKho";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKho", maKho);
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
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
        public DataTable GetLoHangByMaHoaDon(int maHoaDon)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM LoHang LH, HangHoa HH WHERE LH.MaHangHoa = HH.MaHangHoa AND MaHoaDonMua = @MaHoaDon";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
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
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
        public bool AddLoHang(DTO_LoHang newLoHang)
        {
            try
            {
                string sql = "INSERT INTO LoHang (DonGia, SoLuong, SoLuongTonKho, NgaySanXuat, HanSuDung, MaHoaDonMua, MaKho, MaHangHoa) " +
                    "VALUES (@DonGia, @SoLuong, @SoLuongTonKho, @NgaySanXuat, @HanSuDung, @MaHoaDonMua, @MaKho, @MaHangHoa)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@DonGia", newLoHang.DonGia);
                    cmd.Parameters.AddWithValue("@SoLuong", newLoHang.SoLuong);
                    cmd.Parameters.AddWithValue("@SoLuongTonKho", newLoHang.SoLuongTonKho);
                    cmd.Parameters.AddWithValue("@MaHoaDonMua", newLoHang.MaHoaDonMua);
                    cmd.Parameters.AddWithValue("@MaKho", newLoHang.MaKho);
                    cmd.Parameters.AddWithValue("@MaHangHoa", newLoHang.MaHangHoa);
                    cmd.Parameters.AddWithValue("@NgaySanXuat", newLoHang.NgaySanXuat);
                    cmd.Parameters.AddWithValue("@HanSuDung", newLoHang.HanSuDung);
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
        public bool UpdateLoHang(DTO_LoHang loHang)
        {
            try
            {
                string sql = @"UPDATE LoHang SET 
                           DonGia = @DonGia,
                           SoLuong = @SoLuong,
                           SoLuongTonKho = @SoLuongTonKho,
                           NgaySanXuat = @NSX,
                           HanSuDung = @HSD
                           WHERE MaLoHang = @MaLoHang";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@DonGia", loHang.DonGia);
                    cmd.Parameters.AddWithValue("@SoLuong", loHang.SoLuong);
                    cmd.Parameters.AddWithValue("@SoLuongTonKho", loHang.SoLuongTonKho);
                    cmd.Parameters.AddWithValue("@NSX", loHang.NgaySanXuat);
                    cmd.Parameters.AddWithValue("@HSD", loHang.HanSuDung);
                    cmd.Parameters.AddWithValue("@MaLoHang", loHang.MaLoHang);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("UpdateLoHang Error: " + ex.Message);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}
