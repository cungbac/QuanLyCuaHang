using QuanLyCuaHang.Entities;
using QuanLyCuaHang.XuLyLuuTru;

namespace QuanLyCuaHang.XuLyNghiepVu
{
    public class XL_LoaiHang
    {
        public static LoaiHang[]? DocDanhSach(string tukhoa = "", string danhmuctimkiem = "")
        {
            LoaiHang[] danhSach;
            danhSach = LT_LoaiHang.DocDanhSachLoaiHang();
            // Dem so luong mat hang thoa dieu kien
            int n = 0;
            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhmuctimkiem == "maloaihang")
                {
                    if (danhSach[i].MaLoaiHang.Contains(tukhoa))
                    {
                        n++;
                    }
                }
                else
                {
                    if (danhSach[i].TenLoaiHang.Contains(tukhoa))
                    {
                        n++;
                    }
                }
            }
            // Them mang ket qua
            LoaiHang[]? ketqua = null;
            if (n > 0)
            {
                ketqua = new LoaiHang[n];
                int j = 0;
                for (int i = 0; i < danhSach.Length; i++)
                {
                    if (danhmuctimkiem == "maloaihang")
                    {
                        if (danhSach[i].MaLoaiHang.Contains(tukhoa))
                        {
                            ketqua[j++] = danhSach[i];
                        }
                    }
                    else
                    {
                        if (danhSach[i].TenLoaiHang.Contains(tukhoa))
                        {
                            ketqua[j++] = danhSach[i];
                        }
                    }
                }
            }
            return ketqua;
        }
        public static LoaiHang? DocThongTinChiTietLoaiHang(string maLoaiHang)
        {
            LoaiHang? kq = null;
            kq = LT_LoaiHang.DocThongTinChiTietLoaiHang(maLoaiHang);
            return kq;
        }
        public static string KiemTraHopLe(LoaiHang loaiHang)
        {
            string chuoi = string.Empty;
            if (loaiHang.TenLoaiHang.Length > 100)
            {
                chuoi = "Tên loại hàng không hợp lệ";
            }
            if (loaiHang.MaLoaiHang.Contains(" "))
            {
                chuoi = "Mã loại hàng không được có khoảng trắng!";
            }
            return chuoi;
        }
        public static bool KiemTraLoaiHang(string tenLoaiHang)
        {
            LoaiHang[] danhSach = DocDanhSach();
            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhSach[i].TenLoaiHang == tenLoaiHang)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool KiemTraMaLoaiHang(string maLh)
        {
            LoaiHang[] danhSach = DocDanhSach();
            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhSach[i].MaLoaiHang == maLh)
                {
                    return true;
                }
            }
            return false;
        }
        public static string ThemLoaiHang(LoaiHang loaiHang)
        {
            string chuoi = KiemTraHopLe(loaiHang);
            bool isValid = (chuoi == string.Empty);
            if (isValid)
            {
                LT_LoaiHang.ThemLoaiHang(loaiHang);
            }
            return chuoi;
        }
        public static string SuaLoaiHang(LoaiHang loaiHang)
        {
            string chuoi = string.Empty;
            bool isValid = (chuoi == string.Empty);
            if (isValid)
            {
                LT_LoaiHang.SuaLoaiHang(loaiHang);
            }
            return chuoi;
        }
        public static string XoaLoaiHang(string maLoaiHang)
        {
            string chuoi = string.Empty;
            LT_LoaiHang.XoaLoaiHang(maLoaiHang);
            return chuoi;
        }
        public static string[] LayDanhSachTenLoaiHang()
        {
            LoaiHang[] danhSach;
            danhSach = LT_LoaiHang.DocDanhSachLoaiHang();

            int n = danhSach.Length;
            string[] danhSachTenLoaiHang = new string[n];
            for (int i = 0; i < n; i++)
            {
                danhSachTenLoaiHang[i] = danhSach[i].TenLoaiHang;
            }
            return danhSachTenLoaiHang;
        }
    }
}
