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
    public class DAL_CaLamViec : DBConnect
    {
        public DataTable GetCaLamViec()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM CaLamViec";
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
                Console.WriteLine("Lỗi lấy danh sách ca làm việc: " + ex.Message);
                return null;
            }
        }
        public DataTable GetCaLamViec(DateTime tuNgay, DateTime denNgay)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM CaLamViec WHERE NgayLamViec >= @TuNgay AND NgaylamViec <= @DenNgay";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay);
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
                Console.WriteLine("Lỗi lấy ca làm việc theo ngày: " + ex.Message);
                return null;
            }
        }
        public bool AddCaLamViec(DTO_CaLamViec newCaLamViec)
        {
            try
            {
                string sql = "INSERT INTO CaLamViec (NgayLamViec, GioBatDau, GioKetThuc, GhiChu) VALUES (@NgayLamViec, @GioBatDau, @GioKetThuc, @GhiChu)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@NgayLamViec", newCaLamViec.NgayLamViec);
                    cmd.Parameters.AddWithValue("@GioBatDau", newCaLamViec.GioBatDau);
                    cmd.Parameters.AddWithValue("@GioKetThuc", newCaLamViec.GioKetThuc);
                    cmd.Parameters.AddWithValue("@GhiChu", newCaLamViec.GhiChu);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm ca làm việc: " + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool UpdateCaLamViec(DTO_CaLamViec updatedCaLamViec)
        {
            try
            {
                string sql = "UPDATE CaLamViec SET NgayLamViec = @NgayLamViec, GioBatDau = @GioBatDau, GioKetThuc = @GioKetThuc, GhiChu = @GhiChu WHERE MaCa = @MaCaLamViec";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaCaLamViec", updatedCaLamViec.MaCa);
                    cmd.Parameters.AddWithValue("@NgayLamViec", updatedCaLamViec.NgayLamViec);
                    cmd.Parameters.AddWithValue("@GioBatDau", updatedCaLamViec.GioBatDau);
                    cmd.Parameters.AddWithValue("@GioKetThuc", updatedCaLamViec.GioKetThuc);
                    cmd.Parameters.AddWithValue("@GhiChu", updatedCaLamViec.GhiChu);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi cập nhật ca làm việc: " + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool DeleteCaLamViec(int maCaLamViec)
        {
            try
            {
                string sql = "DELETE FROM CaLamViec WHERE MaCa = @MaCaLamViec";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaCaLamViec", maCaLamViec);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xóa ca làm việc: " + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
