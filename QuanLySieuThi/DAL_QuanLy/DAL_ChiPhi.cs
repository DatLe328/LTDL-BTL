using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_ChiPhi : DBConnect
    {
        public bool AddChiPhi(DTO_QuanLy.DTO_ChiPhi newChiPhi)
        {
            try
            {
                string sql = "INSERT INTO ChiPhi (TenChiPhi, SoTien, NgayLap, MoTa) VALUES (@TenChiPhi, @SoTien, @NgayLap, @MoTa)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TenChiPhi", newChiPhi.TenChiPhi);
                    cmd.Parameters.AddWithValue("@SoTien", newChiPhi.SoTien);
                    cmd.Parameters.AddWithValue("@NgayLap", newChiPhi.NgayLap);
                    cmd.Parameters.AddWithValue("@MoTa", newChiPhi.MoTa);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm chi phí: " + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool UpdateChiPhi(DTO_QuanLy.DTO_ChiPhi updatedChiPhi)
        {
            try
            {
                string sql = "UPDATE ChiPhi SET TenChiPhi = @TenChiPhi, SoTien = @SoTien, NgayLap = @NgayLap, MoTa = @MoTa WHERE MaChiPhi = @MaChiPhi";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaChiPhi", updatedChiPhi.MaChiPhi);
                    cmd.Parameters.AddWithValue("@TenChiPhi", updatedChiPhi.TenChiPhi);
                    cmd.Parameters.AddWithValue("@SoTien", updatedChiPhi.SoTien);
                    cmd.Parameters.AddWithValue("@NgayLap", updatedChiPhi.NgayLap);
                    cmd.Parameters.AddWithValue("@MoTa", updatedChiPhi.MoTa);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi cập nhật chi phí: " + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool DeleteChiPhi(int maChiPhi)
        {
            try
            {
                string sql = "DELETE FROM ChiPhi WHERE MaChiPhi = @MaChiPhi";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaChiPhi", maChiPhi);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xóa chi phí: " + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable GetChiPhi()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM ChiPhi";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi truy vấn danh sách chi phí: " + ex.Message);
                return null;
            }
        }

        public DataTable GetChiPhiByDate(DateTime ngay)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM ChiPhi WHERE CAST(NgayLap AS DATE) = @Ngay";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Ngay", ngay.Date);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi truy vấn chi phí theo ngày: " + ex.Message);
                return null;
            }
        }
        public DataTable GetThongKeChiPhiTheoThang()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT FORMAT(NgayLap, 'yyyy-MM') AS Thang, SUM(SoTien) AS TongTien FROM ChiPhi GROUP BY FORMAT(NgayLap, 'yyyy-MM') ORDER BY Thang";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thống kê: " + ex.Message);
                return null;
            }
        }

    }
}
