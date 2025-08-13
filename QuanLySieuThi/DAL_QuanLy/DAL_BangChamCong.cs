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
    public class DAL_BangChamCong : DBConnect
    {
        public bool AddBangChamCong(DTO_BangChamCong bangChamCong)
        {
            try
            {
                string sql = "INSERT INTO BangChamCong (MaNhanVien, NgayChamCong, GioVao, GioRa, TrangThai) VALUES (@MaNhanVien, @NgayChamCong, @GioVao, @GioRa, @TrangThai)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNhanVien", bangChamCong.MaNhanVien);
                    cmd.Parameters.AddWithValue("@NgayChamCong", bangChamCong.NgayChamCong);
                    cmd.Parameters.AddWithValue("@GioVao", bangChamCong.GioVao);
                    cmd.Parameters.AddWithValue("@GioRa", bangChamCong.GioRa);
                    cmd.Parameters.AddWithValue("@TrangThai", bangChamCong.TrangThai);
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding BangChamCong: " + ex.Message);
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
        public bool AddBangChamCong(int maNhanVien, DateTime ngayChamCong, TimeSpan gioVao, string trangThai, int maCa)
        {
            try
            {
                string sql = "INSERT INTO BangChamCong (MaNhanVien, NgayChamCong, GioVao, TrangThai, MaCa) VALUES (@MaNhanVien, @NgayChamCong, @GioVao, @TrangThai, @MaCa)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    cmd.Parameters.AddWithValue("@NgayChamCong", ngayChamCong);
                    cmd.Parameters.AddWithValue("@GioVao", gioVao);
                    cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                    cmd.Parameters.AddWithValue("@MaCa", maCa);
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding BangChamCong: " + ex.Message);
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
        public DTO_BangChamCong GetBangChamCongByMaChamCong(int maChamCong)
        {
            DTO_BangChamCong bangChamCong = null;
            try
            {
                string sql = "SELECT * FROM BangChamCong WHERE MaChamCong = @MaChamCong";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaChamCong", maChamCong);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bangChamCong = new DTO_BangChamCong
                            {
                                MaChamCong = reader.GetInt32(reader.GetOrdinal("MaChamCong")),
                                MaNhanVien = reader.GetInt32(reader.GetOrdinal("MaNhanVien")),
                                NgayChamCong = reader.GetDateTime(reader.GetOrdinal("NgayChamCong")),
                                GioVao = reader.GetTimeSpan(reader.GetOrdinal("GioVao")),
                                GioRa = reader.IsDBNull(reader.GetOrdinal("GioRa")) ? TimeSpan.Zero : reader.GetTimeSpan(reader.GetOrdinal("GioRa")),
                                TrangThai = reader.GetString(reader.GetOrdinal("TrangThai")),
                                MaCa = reader.GetInt32(reader.GetOrdinal("MaCa"))
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving BangChamCong: " + ex.Message);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return bangChamCong;
        }
        public DataTable GetBangChamCong(int maNhanVien)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM BangChamCong WHERE MaNhanVien = @MaNhanVien";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    conn.Open();
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving BangChamCong: " + ex.Message);
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
        public DataTable GetBangChamCong(int maNhanVien, DateTime tuNgay, DateTime denNgay)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM BangChamCong WHERE MaNhanVien = @MaNhanVien AND NgayChamCong >= @TuNgay AND NgayChamCong <= @DenNgay";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay);
                    conn.Open();
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving BangChamCong by date: " + ex.Message);
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
        public DTO_BangChamCong GetBangChamCongToDay(int maNhanVien)
        {
            DTO_BangChamCong bangChamCong = null;
            try
            {
                string sql = "SELECT * FROM BangChamCong WHERE MaNhanVien = @MaNhanVien AND CAST(NgayChamCong AS DATE) = CAST(GETDATE() AS DATE)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bangChamCong = new DTO_BangChamCong
                            {
                                MaChamCong = reader.GetInt32(reader.GetOrdinal("MaChamCong")),
                                MaNhanVien = reader.GetInt32(reader.GetOrdinal("MaNhanVien")),
                                NgayChamCong = reader.GetDateTime(reader.GetOrdinal("NgayChamCong")),
                                GioVao = reader.GetTimeSpan(reader.GetOrdinal("GioVao")),
                                GioRa = reader.IsDBNull(reader.GetOrdinal("GioRa")) ? TimeSpan.Zero : reader.GetTimeSpan(reader.GetOrdinal("GioRa")),
                                TrangThai = reader.GetString(reader.GetOrdinal("TrangThai"))
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving today's BangChamCong: " + ex.Message);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return bangChamCong;
        }
        public int GetMaChamCongLatest(int maNhanVien)
        {
            int maChamCong = 0;
            try
            {
                string sql = "SELECT TOP 1 MaChamCong FROM BangChamCong WHERE MaNhanVien = @MaNhanVien ORDER BY NgayChamCong DESC, GioVao DESC";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        maChamCong = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving latest MaChamCong: " + ex.Message);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return maChamCong;
        }
        public bool UpdateBangChamCong(int maChamCong, DateTime gioRa, string trangThai)
        {
            try
            {
                string sql = "UPDATE BangChamCong SET GioRa = @GioRa, TrangThai = @TrangThai WHERE MaChamCong = @MaChamCong";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaChamCong", maChamCong);
                    cmd.Parameters.AddWithValue("@GioRa", gioRa);
                    cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating BangChamCong: " + ex.Message);
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

        //Bao cao thong ke
        public DataTable ThongKeNgayCongTheoThang(int thang, int nam)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = @"
                SELECT nv.HoTenNV AS TenNhanVien,
                COUNT(*) AS SoNgayCong
                FROM BangChamCong cc
                JOIN NhanVien nv ON cc.MaNhanVien = nv.MaNhanVien
                WHERE MONTH(cc.NgayChamCong) = @Thang
                AND YEAR(cc.NgayChamCong) = @Nam
                AND cc.TrangThai LIKE N'%chấm công%'
                GROUP BY nv.HoTenNV
                ORDER BY SoNgayCong DESC";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Thang", thang);
                    cmd.Parameters.AddWithValue("@Nam", nam);
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
                Console.WriteLine("Lỗi thống kê ngày công: " + ex.Message);
            }
            return dt;
        }

    }
}
