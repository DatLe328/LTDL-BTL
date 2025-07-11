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
                string query = "SELECT * FROM HoaDonMua WHERE CAST(NgayNhap AS DATE) = @NgayNhap";
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



    }
}
