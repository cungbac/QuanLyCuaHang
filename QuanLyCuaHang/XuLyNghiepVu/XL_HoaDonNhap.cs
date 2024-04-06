using QuanLyCuaHang.Entities;
using QuanLyCuaHang.XuLyLuuTru;

namespace QuanLyCuaHang.XuLyNghiepVu
{
    public class XL_HoaDonNhap
    {
        public static HoaDonNhapHang[]? DocDanhSach(string tukhoa = "", string danhmuctimkiem = "")
        {
            HoaDonNhapHang[] danhSach;
            danhSach = LT_HoaDonNhap.DocDanhSachHoaDon();
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
            HoaDonNhapHang[]? ketqua = null;
            if (n > 0)
            {
                ketqua = new HoaDonNhapHang[n];
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
        public static HoaDonNhapHang? DocThongTinChiTietHoaDon(string maHd)
        {
            HoaDonNhapHang? kq = null;
            kq = LT_HoaDonNhap.DocThongTinChiTietHoaDon(maHd);
            return kq;
        }
        public static string KiemTraHopLe(HoaDonNhapHang hd)
        {
            string chuoi = string.Empty;
            if (hd.GiaNhap < 0)
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
            HoaDonNhapHang[] danhSach = DocDanhSach();
            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhSach[i].MaHoaDon == maHd)
                {
                    return true;
                }
            }
            return false;
        }
        public static string ThemHoaDon(HoaDonNhapHang hd)
        {
            string chuoi = KiemTraHopLe(hd);
            bool isValid = (chuoi == string.Empty);
            if (isValid)
            {
                LT_HoaDonNhap.ThemHoaDon(hd);
            }
            return chuoi;
        }
        public static string SuaHoaDon(HoaDonNhapHang hd)
        {
            string chuoi = KiemTraHopLe(hd);
            bool isValid = (chuoi == string.Empty);
            if (isValid)
            {
                LT_HoaDonNhap.SuaHoaDon(hd);
            }
            return chuoi;
        }
        public static string XoaHoaDon(string maHd)
        {
            string chuoi = string.Empty;
            LT_HoaDonNhap.XoaHoaDon(maHd);
            return chuoi;
        }
        public static int LaySoLuongNhap(string maHd)
        {
            int kq = 0;
            HoaDonNhapHang[] danhSach = DocDanhSach();
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
