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
    public class DAL_HangHoa : DBConnect
    {
        public bool AddHangHoa(DTO_HangHoa newHangHoa)
        {
            try
            {
                string sql = "INSERT INTO HangHoa (TenHangHoa, DonViTinh, GiaBan, MaLoaiHangHoa, HanSuDungTieuChuan, DonViHanSuDung) " +
                             "VALUES (@TenHangHoa, @DonViTinh, @GiaBan, @MaLoaiHangHoa, @HanSuDungTieuChuan, @DonViHanSuDung)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TenHangHoa", newHangHoa.TenHangHoa);
                    cmd.Parameters.AddWithValue("@DonViTinh", newHangHoa.DonViTinh);
                    cmd.Parameters.AddWithValue("@GiaBan", newHangHoa.GiaBan);
                    cmd.Parameters.AddWithValue("@MaLoaiHangHoa", newHangHoa.MaLoaiHangHoa);
                    cmd.Parameters.AddWithValue("@HanSuDungTieuChuan", newHangHoa.HanSuDungTieuChuan);
                    cmd.Parameters.AddWithValue("@DonViHanSuDung", newHangHoa.DonViHanSuDung);
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
        public bool UpdateHangHoa(DTO_HangHoa updatedHangHoa)
        {
            try
            {
                string sql = "UPDATE HangHoa SET TenHangHoa = @TenHangHoa, DonViTinh = @DonViTinh, " +
                             "GiaBan = @GiaBan, MaLoaiHangHoa = @MaLoaiHangHoa, HanSuDungTieuChuan = @HanSuDungTieuChuan, " +
                             "DonViHanSuDung = @DonViHanSuDung WHERE MaHangHoa = @MaHangHoa";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHangHoa", updatedHangHoa.MaHangHoa);
                    cmd.Parameters.AddWithValue("@TenHangHoa", updatedHangHoa.TenHangHoa);
                    cmd.Parameters.AddWithValue("@DonViTinh", updatedHangHoa.DonViTinh);
                    cmd.Parameters.AddWithValue("@GiaBan", updatedHangHoa.GiaBan);
                    cmd.Parameters.AddWithValue("@MaLoaiHangHoa", updatedHangHoa.MaLoaiHangHoa);
                    cmd.Parameters.AddWithValue("@HanSuDungTieuChuan", updatedHangHoa.HanSuDungTieuChuan);
                    cmd.Parameters.AddWithValue("@DonViHanSuDung", updatedHangHoa.DonViHanSuDung);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        public bool DeleteHangHoa(int maHangHoa)
        {
            try
            {
                string sql = "DELETE FROM HangHoa WHERE MaHangHoa = @MaHangHoa";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHangHoa", maHangHoa);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        public DataTable GetHangHoa(int maHangHoa = -1, string tenHangHoa = "")
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM HangHoa WHERE 1=1";
                using (var cmd = new SqlCommand())
                {
                    if (maHangHoa != -1)
                    {
                        query += " AND MaHangHoa = @MaHang";
                        cmd.Parameters.AddWithValue("@MaHang", maHangHoa);
                    }
                    if (!string.IsNullOrEmpty(tenHangHoa))
                    {
                        query += " AND TenHangHoa LIKE @TenHang";
                        cmd.Parameters.AddWithValue("@TenHang", "%" + tenHangHoa + "%");
                    }
                    cmd.Connection = conn;
                    cmd.CommandText = query;

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return dt;
        }
    }
}
