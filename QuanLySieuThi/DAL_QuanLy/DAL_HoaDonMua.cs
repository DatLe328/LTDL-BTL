using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_HoaDonMua : DBConnect
    {
<<<<<<< HEAD
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
=======
>>>>>>> d5d342419bc507a45661d7dd19d37b585cc2ebd9
        public DataTable GetHoaDonMua()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM HoaDonMua";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
        public DataTable GetHoaDonMuaByDate(DateTime ngayNhap)
        {
            try
            {
                DataTable dt = new DataTable();
<<<<<<< HEAD
                string query = "SELECT * FROM HoaDonMua WHERE CAST(NgayLap AS DATE) = @NgayNhap";
=======
                string query = "SELECT * FROM HoaDonMua WHERE CAST(NgayNhap AS DATE) = @NgayNhap";
>>>>>>> d5d342419bc507a45661d7dd19d37b585cc2ebd9
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NgayNhap", ngayNhap.Date);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi truy vấn hóa đơn mua theo ngày: " + ex.Message);
                return null;
            }
        }
<<<<<<< HEAD
=======



>>>>>>> d5d342419bc507a45661d7dd19d37b585cc2ebd9
    }
}
