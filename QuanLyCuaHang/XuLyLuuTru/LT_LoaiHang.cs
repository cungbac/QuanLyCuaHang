using QuanLyCuaHang.Entities;

namespace QuanLyCuaHang.XuLyLuuTru
{
    public class LT_LoaiHang
    {
        public static void LuuDanhSachLoaiHang(LoaiHang[] loaiHang)
        {
            string dataFile = "D:\\Data\\loaihang.txt";
            StreamWriter writer = new StreamWriter(dataFile);
            writer.WriteLine(loaiHang.Length);
            for (int i = 0; i < loaiHang.Length; i++)
            {
                writer.WriteLine($"{loaiHang[i].MaLoaiHang},{loaiHang[i].TenLoaiHang}");
            }
            writer.Close();
        }
        public static LoaiHang[] DocDanhSachLoaiHang()
        {
            string dataFile = "D:\\Data\\loaihang.txt";

            LoaiHang[] danhSach;
            StreamReader reader = new StreamReader(dataFile);
            string s = reader.ReadLine();
            int n = int.Parse(s);
            danhSach = new LoaiHang[n];
            
            for (int i = 0; i < n; i++)
            {
                s = reader.ReadLine();
                string[] m = s.Split(",");
                danhSach[i].MaLoaiHang = m[0];
                danhSach[i].TenLoaiHang = m[1];
            }
            reader.Close();
            return danhSach;
        }
        public static LoaiHang? DocThongTinChiTietLoaiHang(string maLoaiHang)
        {
            LoaiHang[] danhSach = DocDanhSachLoaiHang();
            foreach (LoaiHang lh in danhSach)
            {
                if (lh.MaLoaiHang == maLoaiHang)
                {
                    return lh;
                }
            }
            return null;
        }
        public static void ThemLoaiHang(LoaiHang loaiHang)
        {
            LoaiHang[] danhSach = DocDanhSachLoaiHang();
            LoaiHang[] danhSachMoi = new LoaiHang[danhSach.Length + 1];
            for (int i = 0; i < danhSach.Length; i++)
            {
                danhSachMoi[i] = danhSach[i];
            }
            danhSachMoi[danhSach.Length] = loaiHang;
            LuuDanhSachLoaiHang(danhSachMoi);
        }
        public static void SuaLoaiHang(LoaiHang loaiHang)
        {
            LoaiHang[] danhSach = DocDanhSachLoaiHang();
            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhSach[i].MaLoaiHang == loaiHang.MaLoaiHang)
                {
                    danhSach[i] = loaiHang;
                }
            }
            LuuDanhSachLoaiHang(danhSach);
        }
        public static void XoaLoaiHang(string maLoaiHang)
        {
            LoaiHang[] danhSach = DocDanhSachLoaiHang();
            LoaiHang[] danhSachMoi = new LoaiHang[danhSach.Length - 1];
            int j = 0;
            for (int i = 0;i < danhSach.Length; i++)
            {
                if (danhSach[i].MaLoaiHang != maLoaiHang)
                {
                    danhSachMoi[j] = danhSach[i];
                    j++;
                }
            }
            LuuDanhSachLoaiHang(danhSachMoi);
        }
    }
}
