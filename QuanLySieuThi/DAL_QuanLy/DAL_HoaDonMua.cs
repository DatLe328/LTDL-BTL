using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_HoaDonMua : DBConnect
    {
        public bool AddHoaDonMua(DTO_QuanLy.DTO_HoaDonMua newHoaDonMua)
        {
            try
            {
                string sql = "INSERT INTO HoaDonMua (MaNCC, NgayLap, TongTien) VALUES (@MaNCC, @NgayLap, @TongTien)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNCC", newHoaDonMua.MaNCC);
                    cmd.Parameters.AddWithValue("@NgayLap", newHoaDonMua.NgayLap);
                    cmd.Parameters.AddWithValue("@TongTien", newHoaDonMua.TongTien);
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
        public int GetLastHoaDonMuaId()
        {
            try
            {
                string sql = "SELECT MAX(MaHoaDonMua) FROM HoaDonMua";
                using (var cmd = new SqlCommand(sql, conn))
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
                conn.Close();
            }
        }
        public bool UpdateHoaDonMua(DTO_QuanLy.DTO_HoaDonMua updatedHoaDonMua)
        {
            try
            {
                string sql = "UPDATE HoaDonMua SET MaNCC = @MaNCC, NgayLap = @NgayLap, TongTien = @TongTien WHERE MaHoaDonMua = @MaHoaDonMua";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHoaDonMua", updatedHoaDonMua.MaHoaDon);
                    cmd.Parameters.AddWithValue("@MaNCC", updatedHoaDonMua.MaNCC);
                    cmd.Parameters.AddWithValue("@NgayLap", updatedHoaDonMua.NgayLap);
                    cmd.Parameters.AddWithValue("@TongTien", updatedHoaDonMua.TongTien);
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
