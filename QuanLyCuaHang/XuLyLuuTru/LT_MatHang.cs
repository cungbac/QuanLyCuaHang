using QuanLyCuaHang.Entities;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace QuanLyCuaHang.XuLyLuuTru
{
    public class LT_MatHang
    {
        public static void LuuDanhSachMatHang(MatHang[] mathang)
        {
            string dataFile = "D:\\Data\\mathang.txt";
            StreamWriter writer = new StreamWriter(dataFile);
            writer.WriteLine(mathang.Length);
            for (int i = 0; i < mathang.Length; i++)
            {
                writer.WriteLine(
                    $"{mathang[i].MaHang}" +
                    $",{mathang[i].TenHang}" +
                    $",{mathang[i].HanDung}" +
                    $",{mathang[i].CongTySanXuat}" +
                    $",{mathang[i].NgaySanXuat}" +
                    $",{mathang[i].LoaiHang}" +
                    $",{mathang[i].GiaBan}");
            }
            writer.Close();
        }
        public static MatHang[] DocDanhSachMatHang()
        {
            string dataFile = "D:\\Data\\mathang.txt";

            MatHang[] danhSach;
            StreamReader reader = new StreamReader(dataFile);
            string s = reader.ReadLine();
            int n = int.Parse(s);
            danhSach = new MatHang[n];
            
            for (int i = 0; i < n; i++)
            {
                s = reader.ReadLine();
                string[] m = s.Split(",");
                danhSach[i].MaHang = m[0];
                danhSach[i].TenHang = m[1];
                danhSach[i].HanDung = DateOnly.Parse(m[2]);
                danhSach[i].CongTySanXuat = m[3];
                danhSach[i].NgaySanXuat = DateOnly.Parse(m[4]);
                danhSach[i].LoaiHang = m[5];
                danhSach[i].GiaBan = int.Parse(m[6]);
            }
            reader.Close();
            return danhSach;
        }
        public static MatHang? DocThongTinChiTietMatHang(string maHang)
        {
            MatHang[] danhSach = DocDanhSachMatHang();
            foreach (MatHang mh  in danhSach)
            {
                if (mh.MaHang == maHang)
                {
                    return mh;
                }
            }
            return null;
        }
        public static void ThemMatHang(MatHang mh)
        {
            MatHang[] danhSach = DocDanhSachMatHang();
            MatHang[] danhSachMoi = new MatHang[danhSach.Length + 1];
            for (int i = 0; i < danhSach.Length; i++)
            {
                danhSachMoi[i] = danhSach[i];
            }
            danhSachMoi[danhSach.Length] = mh;
            LuuDanhSachMatHang(danhSachMoi);
        }
        public static void SuaMatHang(MatHang mh)
        {
            MatHang[] danhSach = DocDanhSachMatHang();
            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhSach[i].MaHang == mh.MaHang)
                {
                    danhSach[i] = mh;
                }
            }
            LuuDanhSachMatHang(danhSach);
        }
        public static void XoaMatHang(string maHang)
        {
            MatHang[] danhSach = DocDanhSachMatHang();
            MatHang[] danhSachMoi = new MatHang[danhSach.Length - 1];
            int j = 0;
            for (int i=0; i < danhSach.Length; i++)
            {
                if (danhSach[i].MaHang != maHang)
                {
                    danhSachMoi[j] = danhSach[i];
                    j++;
                }
            }
            LuuDanhSachMatHang(danhSachMoi);
        }
        public static void LuuDanhSachTonKho(MatHangTonKho[] mathang)
        {
            string dataFile = "D:\\Data\\mathangtonkho.txt";
            StreamWriter writer = new StreamWriter(dataFile);
            writer.WriteLine(mathang.Length);
            for (int i = 0; i < mathang.Length; i++)
            {
                writer.WriteLine(
                    $"{mathang[i].MaHang}" +
                    $",{mathang[i].TenHang}" +
                    $",{mathang[i].LoaiHang}" +
                    $",{mathang[i].CongTySanXuat}" +
                    $",{mathang[i].NgaySanXuat}" +
                    $",{mathang[i].HanDung}" +
                    $",{mathang[i].SoLuongTonKho}");
            }
            writer.Close();
        }
        public static MatHangTonKho[] DocDanhSachTonKho()
        {
            string dataFile = "D:\\Data\\mathangtonkho.txt";
            MatHangTonKho[] danhSach;
            StreamReader reader = new StreamReader(dataFile);
            string s = reader.ReadLine();
            int n = int.Parse(s);
            danhSach = new MatHangTonKho[n];

            for (int i = 0; i < danhSach.Length; ++i)
            {
                s = reader.ReadLine();
                string[] m = s.Split(",");
                danhSach[i].MaHang = m[0];
                danhSach[i].TenHang = m[1];
                danhSach[i].LoaiHang = m[2];
                danhSach[i].CongTySanXuat = m[3];
                danhSach[i].NgaySanXuat = DateOnly.Parse(m[4]);
                danhSach[i].HanDung = DateOnly.Parse(m[5]);
                danhSach[i].SoLuongTonKho = int.Parse(m[6]);
            }
            reader.Close();
            return danhSach;
        }
        public static void ThemMatHangTonKho(MatHangTonKho mh)
        {
            MatHangTonKho[] danhSach = DocDanhSachTonKho();
            MatHangTonKho[] danhSachMoi = new MatHangTonKho[danhSach.Length + 1];
            for (int i = 0; i < danhSach.Length; i++)
            {
                danhSachMoi[i] = danhSach[i];
            }
            danhSachMoi[danhSach.Length] = mh;
            LuuDanhSachTonKho(danhSachMoi);
        }
        public static void SuaMatHangTonKho(MatHangTonKho mh)
        {
            MatHangTonKho[] danhSach = DocDanhSachTonKho();
            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhSach[i].MaHang == mh.MaHang)
                {
                    danhSach[i] = mh;
                }
            }
            LuuDanhSachTonKho(danhSach);
        }
        public static void XoaMatHangTonKho(string maHang)
        {
            MatHangTonKho[] danhSach = DocDanhSachTonKho();
            MatHangTonKho[] danhSachMoi = new MatHangTonKho[danhSach.Length - 1];
            int j = 0;
            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhSach[i].MaHang != maHang)
                {
                    danhSachMoi[j] = danhSach[i];
                    j++;
                }
            }
            LuuDanhSachTonKho(danhSachMoi);
        }
    }
}
