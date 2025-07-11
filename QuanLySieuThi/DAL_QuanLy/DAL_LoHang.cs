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
        public bool UpdateLoHang(DTO_LoHang loHang)
        {
            try
            {
                string sql = @"UPDATE LoHang SET 
                               DonGia = @DonGia,
                               SoLuong = @SoLuong,
                               SoLuongTonKho = @SoLuongTonKho,
                               NSX = @NSX,
                               HSD = @HSD,
                               MaKho = @MaKho,
                               WHERE MaLoHang = @MaLoHang";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@DonGia", loHang.DonGia);
                    cmd.Parameters.AddWithValue("@SoLuong", loHang.SoLuong);
                    cmd.Parameters.AddWithValue("@SoLuongTonKho", loHang.SoLuongTonKho);
                    cmd.Parameters.AddWithValue("@NSX", loHang.NgaySanXuat);
                    cmd.Parameters.AddWithValue("@HSD", loHang.HanSuDung);
                    cmd.Parameters.AddWithValue("@MaHoaDonMua", loHang.MaHoaDonMua);
                    cmd.Parameters.AddWithValue("@MaHangHoa", loHang.MaHangHoa);
                    cmd.Parameters.AddWithValue("@MaKho", loHang.MaKho);
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
        public bool DeleteLoHang(int maLo)
        {
            try
            {
                string sql = "DELETE FROM LoHang WHERE MaLo = @MaLo";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaLo", maLo);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DeleteLoHang Error: " + ex.Message);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
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

        public bool DeleteLoHang(DTO_LoHang newLoHang)
        {
            throw new NotImplementedException();
        }
    }
}
