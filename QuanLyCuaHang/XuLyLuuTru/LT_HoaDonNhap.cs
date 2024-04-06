using Newtonsoft.Json;
using QuanLyCuaHang.Entities;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace QuanLyCuaHang.XuLyLuuTru
{
    public class LT_HoaDonNhap
    {
        public static void LuuDanhSachHoaDon(HoaDonNhapHang[] hd)
        {
            string dataFile = "D:\\Data\\hoadonnhaphang.txt";
            StreamWriter writer = new StreamWriter(dataFile);
            writer.WriteLine(hd.Length);
            for (int i = 0; i < hd.Length; i++)
            {
                writer.WriteLine(
                    $"{hd[i].MaHoaDon}" +
                    $",{hd[i].NgayTao}" +
                    $",{hd[i].MaHang}" +
                    $",{hd[i].TenHang}" +
                    $",{hd[i].SoLuong}" +
                    $",{hd[i].GiaNhap}" +
                    $",{hd[i].ThanhTien}"
                );
            }
            writer.Close();
        }
        public static HoaDonNhapHang[] DocDanhSachHoaDon()
        {
            string dataFile = "D:\\Data\\hoadonnhaphang.txt";

            HoaDonNhapHang[] danhSach;
            StreamReader reader = new StreamReader(dataFile);
            string s = reader.ReadLine();
            int n = int.Parse(s);
            danhSach = new HoaDonNhapHang[n];
            for (int i = 0; i < n; i++)
            {
                s = reader.ReadLine();
                string[] m = s.Split(",");
                danhSach[i].MaHoaDon = m[0];
                danhSach[i].NgayTao = DateOnly.Parse(m[1]);
                danhSach[i].MaHang = m[2];
                danhSach[i].TenHang = m[3];
                danhSach[i].SoLuong = int.Parse(m[4]);
                danhSach[i].GiaNhap = double.Parse(m[5]);
                danhSach[i].ThanhTien = double.Parse(m[6]);
            }
            reader.Close();
            return danhSach;
        }
        public static HoaDonNhapHang? DocThongTinChiTietHoaDon(string maHd)
        {
            HoaDonNhapHang[] danhSach = DocDanhSachHoaDon();
            foreach (HoaDonNhapHang hd in danhSach)
            {
                if (hd.MaHoaDon == maHd)
                {
                    return hd;
                }
            }
            return null;
        }
        public static void ThemHoaDon(HoaDonNhapHang hd)
        {
            HoaDonNhapHang[] danhSach = DocDanhSachHoaDon();
            HoaDonNhapHang[] danhSachMoi = new HoaDonNhapHang[danhSach.Length + 1];
            for (int i = 0; i < danhSach.Length; i++)
            {
                danhSachMoi[i] = danhSach[i];
            }
            danhSachMoi[danhSach.Length] = hd;
            LuuDanhSachHoaDon(danhSachMoi);
        }
        public static void SuaHoaDon(HoaDonNhapHang hd)
        {
            HoaDonNhapHang[] danhSach = DocDanhSachHoaDon();
            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhSach[i].MaHoaDon == hd.MaHoaDon)
                {
                    danhSach[i] = hd;
                }
            }
            LuuDanhSachHoaDon(danhSach);
        }
        public static void XoaHoaDon(string maHd)
        {
            HoaDonNhapHang[] danhSach = DocDanhSachHoaDon();
            HoaDonNhapHang[] danhSachMoi = new HoaDonNhapHang[danhSach.Length - 1];
            int j = 0;
            for (int i=0; i < danhSach.Length; i++)
            {
                if (danhSach[i].MaHoaDon != maHd)
                {
                    danhSachMoi[j] = danhSach[i];
                    j++;
                }
            }
            LuuDanhSachHoaDon(danhSachMoi);
        }
    }
}
