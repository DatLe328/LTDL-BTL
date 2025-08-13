using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QuanLy
{
    public class Utils
    {
        public static void MyDataGridViewFormat(DataGridView dgv)
        {
            if (dgv != null)
            {
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = false;
                dgv.ReadOnly = true;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }
        public static int CountWeekdays(DateTime startDate, DateTime endDate)
        {
            int count = 0;
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek >= Globals.StartWorkDay && date.DayOfWeek <= Globals.EndWorkDay)
                {
                    count++;
                }
            }
            return count;
        }
        public static bool IsInWorkDay(DateTime date)
        {
            return date.DayOfWeek >= Globals.StartWorkDay && date.DayOfWeek <= Globals.EndWorkDay;
        }
        public static DateTime Clamp(DateTime x, DateTime lo, DateTime hi)
        {
            if (x < lo) return lo;
            if (x > hi) return hi;
            return x;
        }

        public static int OverlapMinutes(DateTime aStart, DateTime aEnd, DateTime bStart, DateTime bEnd)
        {
            var start = aStart > bStart ? aStart : bStart;
            var end = aEnd < bEnd ? aEnd : bEnd;
            return (int)Math.Max(0, (end - start).TotalMinutes);
        }

        public static TimeSpan GetTimeSpanCell(DataGridViewRow row, string colName)
        {
            var val = row.Cells[colName].Value;
            if (val is TimeSpan ts) return ts;
            if (val is string s && TimeSpan.TryParse(s, out var parsed)) return parsed;
            throw new InvalidCastException($"Cột {colName} không phải TimeSpan hợp lệ.");
        }
    }
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            if (field != null)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0)
                {
                    return attributes[0].Description;
                }
            }
            return value.ToString();
        }

        public static List<string> GetDescriptions<TEnum>() where TEnum : Enum
        {
            return Enum.GetValues(typeof(TEnum))
                       .Cast<Enum>()
                       .Select(e => e.GetDescription())
                       .ToList();
        }
        public static List<KeyValuePair<TEnum, string>> GetEnumKeyValuePairs<TEnum>() where TEnum : Enum
        {
            return Enum.GetValues(typeof(TEnum))
                       .Cast<TEnum>()
                       .Select(e => new KeyValuePair<TEnum, string>(e, e.GetDescription()))
                       .ToList();
        }
    }
}
