using QuanLyCuaHang.Entities;
using QuanLyCuaHang.XuLyLuuTru;

namespace QuanLyCuaHang.XuLyNghiepVu
{
    public class XL_HoaDonBan
    {
        public static HoaDonBanHang[]? DocDanhSach(string tukhoa = "", string danhmuctimkiem = "")
        {
            HoaDonBanHang[] danhSach;
            danhSach = LT_HoaDonBan.DocDanhSachHoaDon();
            // Dem so luong hoa don thoa dieu kien
            int n = 0;
            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhmuctimkiem == "mahoadon")
                {
                    if (danhSach[i].MaHoaDon.Contains(tukhoa))
                    {
                        n++;
                    }
                }
                else if (danhmuctimkiem == "mahang")
                {
                    if (danhSach[i].MaHang.Contains(tukhoa))
                    {
                        n++;
                    }
                }
                else
                {
                    if (danhSach[i].TenHang.Contains(tukhoa))
                    {
                        n++;
                    }
                }
            }
            // Them mang ket qua
            HoaDonBanHang[]? ketqua = null;
            if (n > 0)
            {
                ketqua = new HoaDonBanHang[n];
                int j = 0;
                for (int i = 0; i < danhSach.Length; i++)
                {
                    if (danhmuctimkiem == "mahoadon")
                    {
                        if (danhSach[i].MaHoaDon.Contains(tukhoa))
                        {
                            ketqua[j++] = danhSach[i];
                        }
                    }
                    else if (danhmuctimkiem == "mahang")
                    {
                        if (danhSach[i].MaHang.Contains(tukhoa))
                        {
                            ketqua[j++] = danhSach[i];
                        }
                    }
                    else
                    {
                        if (danhSach[i].TenHang.Contains(tukhoa))
                        {
                            ketqua[j++] = danhSach[i];
                        }
                    }
                }
            }
            return ketqua;
        }
        public static HoaDonBanHang? DocThongTinChiTietHoaDon(string maHd)
        {
            HoaDonBanHang? kq = null;
            kq = LT_HoaDonBan.DocThongTinChiTietHoaDon(maHd);
            return kq;
        }
        public static string KiemTraHopLe(HoaDonBanHang hd)
        {
            string chuoi = string.Empty;
            if (hd.GiaBan < 0)
            {
                chuoi = "Giá bán không hợp lệ";
            }
            if (hd.MaHoaDon.Contains(" "))
            {
                chuoi = "Mã hóa đơn không được có khoảng trắng!";
            }
            return chuoi;
        }
        public static bool KiemTraMaHoaDon(string maHd)
        {
            HoaDonBanHang[] danhSach = DocDanhSach();
            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhSach[i].MaHoaDon == maHd)
                {
                    return true;
                }
            }
            return false;
        }
        public static string ThemHoaDon(HoaDonBanHang hd)
        {
            string chuoi = KiemTraHopLe(hd);
            bool isValid = (chuoi == string.Empty);
            if (isValid)
            {
                LT_HoaDonBan.ThemHoaDon(hd);
            }
            return chuoi;
        }
        public static string SuaHoaDon(HoaDonBanHang hd)
        {
            string chuoi = KiemTraHopLe(hd);
            bool isValid = (chuoi == string.Empty);
            if (isValid)
            {
                LT_HoaDonBan.SuaHoaDon(hd);
            }
            return chuoi;
        }
        public static string XoaHoaDon(string maHd)
        {
            string chuoi = string.Empty;
            LT_HoaDonBan.XoaHoaDon(maHd);
            return chuoi;
        }
        public static int LaySoLuongBan(string maHd)
        {
            int kq = 0;
            HoaDonBanHang[] danhSach = DocDanhSach();
            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhSach[i].MaHoaDon == maHd)
                {
                    kq = danhSach[i].SoLuong;
                }
            }
            return kq;
        }
    }
}
