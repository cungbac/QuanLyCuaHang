using QuanLyCuaHang.Entities;
using QuanLyCuaHang.XuLyLuuTru;
using QuanLyCuaHang.XuLyNghiepVu;

namespace QuanLyCuaHang.XuLyNghiepVu
{
    public class XL_MatHang
    {
        public static MatHang[]? DocDanhSach(string tukhoa = "", string danhmuctimkiem = "")
        {
            MatHang[] danhSach;
            danhSach = LT_MatHang.DocDanhSachMatHang();
            // Dem so luong mat hang thoa dieu kien
            int n = 0;
            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhmuctimkiem == "mahang")
                {
                    if (danhSach[i].MaHang.Contains(tukhoa))
                    {
                        n++;
                    }
                }
                else if (danhmuctimkiem == "loaihang")
                {
                    if (danhSach[i].LoaiHang.Contains(tukhoa))
                    {
                        n++;
                    }
                }
                else if (danhmuctimkiem == "congtysanxuat")
                {
                    if (danhSach[i].CongTySanXuat.Contains(tukhoa))
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
            MatHang[]? ketqua = null;
            if (n > 0)
            {
                ketqua = new MatHang[n];
                int j = 0;
                for (int i = 0; i < danhSach.Length; i++)
                {
                    if (danhmuctimkiem == "mahang")
                    {
                        if (danhSach[i].MaHang.Contains(tukhoa))
                        {
                            ketqua[j++] = danhSach[i];
                        }
                    }
                    else if (danhmuctimkiem == "loaihang")
                    {
                        if (danhSach[i].LoaiHang.Contains(tukhoa))
                        {
                            ketqua[j++] = danhSach[i];
                        }
                    }
                    else if (danhmuctimkiem == "congtysanxuat")
                    {
                        if (danhSach[i].CongTySanXuat.Contains(tukhoa))
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
        public static MatHang? DocThongTinChiTietMatHang(string maHang)
        {
            MatHang? kq = null;
            kq = LT_MatHang.DocThongTinChiTietMatHang(maHang);
            return kq;
        }
        public static string KiemTraHopLe(MatHang mathang)
        {
            string chuoi = string.Empty;
            bool kiemTraLoaiHang = XL_LoaiHang.KiemTraLoaiHang(mathang.LoaiHang);

            if (mathang.GiaBan < 0)
            {
                chuoi = "Giá bán không hợp lệ!";
            }
            if (string.IsNullOrEmpty(mathang.TenHang))
            {
                chuoi = "Tên mặt hàng không hợp lệ!";
            }
            if (mathang.HanDung < mathang.NgaySanXuat)
            {
                chuoi = "Hạn sử dụng nhỏ hơn Ngày sản xuất!";
            }
            if (!kiemTraLoaiHang)
            {
                chuoi = "Loại hàng không tồn tại!";
            }
            if (mathang.MaHang.Contains(" "))
            {
                chuoi = "Mã hàng không được có khoảng trắng!";
            }
            return chuoi;
        }
        public static bool KiemTraMaHangTrongDanhSachMatHang(string maHang)
        {
            MatHang[] danhSach = DocDanhSach();
            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhSach[i].MaHang == maHang)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool KiemTraMaHangTrongDanhSachTonKho(string maHang)
        {
            MatHangTonKho[] danhSach = DocDanhSachTonKho();
            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhSach[i].MaHang == maHang)
                {
                    return true;
                }
            }
            return false;
        }
        public static string ThemMatHang(MatHang mh)
        {
            string chuoi = KiemTraHopLe(mh);
            bool isValid = (chuoi == string.Empty);
            if (isValid)
            {
                LT_MatHang.ThemMatHang(mh);
            }
            return chuoi;
        }
        public static string SuaMatHang(MatHang mh)
        {
            string chuoi = KiemTraHopLe(mh);
            bool isValid = (chuoi == string.Empty);
            if (isValid)
            {
                LT_MatHang.SuaMatHang(mh);
            }
            return chuoi;
        }
        public static string XoaMatHang(string maHang)
        {
            string chuoi = string.Empty;
            LT_MatHang.XoaMatHang(maHang);
            return chuoi;
        }
        public static MatHangTonKho[]? DocDanhSachTonKho(string tukhoa = "", string danhmuctimkiem = "")
        {
            MatHangTonKho[] danhSach;
            danhSach = LT_MatHang.DocDanhSachTonKho();
            // Dem so luong mat hang thoa dieu kien
            int n = 0;
            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhmuctimkiem == "mahang")
                {
                    if (danhSach[i].MaHang.Contains(tukhoa))
                    {
                        n++;
                    }
                }
                else if (danhmuctimkiem == "loaihang")
                {
                    if (danhSach[i].LoaiHang.Contains(tukhoa))
                    {
                        n++;
                    }
                }
                else if (danhmuctimkiem == "congtysanxuat")
                {
                    if (danhSach[i].CongTySanXuat.Contains(tukhoa))
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
            MatHangTonKho[]? ketqua = null;
            if (n > 0)
            {
                ketqua = new MatHangTonKho[n];
                int j = 0;
                for (int i = 0; i < danhSach.Length; i++)
                {
                    if (danhmuctimkiem == "mahang")
                    {
                        if (danhSach[i].MaHang.Contains(tukhoa))
                        {
                            ketqua[j++] = danhSach[i];
                        }
                    }
                    else if (danhmuctimkiem == "loaihang")
                    {
                        if (danhSach[i].LoaiHang.Contains(tukhoa))
                        {
                            ketqua[j++] = danhSach[i];
                        }
                    }
                    else if (danhmuctimkiem == "congtysanxuat")
                    {
                        if (danhSach[i].CongTySanXuat.Contains(tukhoa))
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
        public static string ThemMatHangTonKho(MatHangTonKho mh)
        {
            string chuoi = string.Empty;
            LT_MatHang.ThemMatHangTonKho(mh);
            chuoi = $"Thêm thành công";
            return chuoi;
        }
        public static string SuaMatHangTonKHo(MatHangTonKho mh)
        {
            string chuoi = string.Empty;
            LT_MatHang.SuaMatHangTonKho(mh);
            chuoi = $"Sửa thành công";
            return chuoi;
        }
        public static string XoaMatHangTonKho(string maHang)
        {
            string chuoi = string.Empty;
            LT_MatHang.XoaMatHang(maHang);
            chuoi = $"Xóa thành công";
            return chuoi;
        }
        public static MatHangTonKho[]? DocDanhSachHetHan(string tukhoa = "", string danhmuctimkiem = "")
        {
            MatHangTonKho[] danhSach;
            danhSach = LT_MatHang.DocDanhSachTonKho();
            DateOnly curDay = DateOnly.FromDateTime(DateTime.Now);
            // Dem so luong mat hang thoa dieu kien
            int n = 0;
            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhSach[i].HanDung < curDay)
                {
                    n++;
                }
            }
            // Them mang ket qua
            MatHangTonKho[]? ketqua = null;
            if (n > 0)
            {
                ketqua = new MatHangTonKho[n];
                int j = 0;
                for (int i = 0; i < danhSach.Length; i++)
                {
                    if (danhSach[i].HanDung < curDay)
                    {
                        ketqua[j++] = danhSach[i];
                    }
                }
            }
            return ketqua;
        }
        public static MatHangTonKho[]? TimDanhSachHetHan(string tukhoa = "", string danhmuctimkiem = "")
        {
            MatHangTonKho[] danhSach;
            danhSach = DocDanhSachHetHan();
            // Dem so luong mat hang thoa dieu kien
            int n = 0;
            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhmuctimkiem == "mahang")
                {
                    if (danhSach[i].MaHang.Contains(tukhoa))
                    {
                        n++;
                    }
                }
                else if (danhmuctimkiem == "loaihang")
                {
                    if (danhSach[i].LoaiHang.Contains(tukhoa))
                    {
                        n++;
                    }
                }
                else if (danhmuctimkiem == "congtysanxuat")
                {
                    if (danhSach[i].CongTySanXuat.Contains(tukhoa))
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
            MatHangTonKho[]? ketqua = null;
            if (n > 0)
            {
                ketqua = new MatHangTonKho[n];
                int j = 0;
                for (int i = 0; i < danhSach.Length; i++)
                {
                    if (danhmuctimkiem == "mahang")
                    {
                        if (danhSach[i].MaHang.Contains(tukhoa))
                        {
                            ketqua[j++] = danhSach[i];
                        }
                    }
                    else if (danhmuctimkiem == "loaihang")
                    {
                        if (danhSach[i].LoaiHang.Contains(tukhoa))
                        {
                            ketqua[j++] = danhSach[i];
                        }
                    }
                    else if (danhmuctimkiem == "congtysanxuat")
                    {
                        if (danhSach[i].CongTySanXuat.Contains(tukhoa))
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
        public static string LayTenMatHang(string maHang)
        {
            MatHang[] danhSach = DocDanhSach();
            string tenHang = string.Empty;
            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhSach[i].MaHang == maHang)
                {
                    tenHang = danhSach[i].TenHang;
                    return tenHang;
                }
            }
            return tenHang;
        }
        public static string LayTenLoaiHang(string maHang)
        {
            MatHang[] danhSach = DocDanhSach();
            string loaiHang = string.Empty;
            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhSach[i].MaHang == maHang)
                {
                    loaiHang = danhSach[i].LoaiHang;
                    return loaiHang;
                }
            }
            return loaiHang;
        }
        public static string LayTenCongTySanXuat(string maHang)
        {
            MatHang[] danhSach = DocDanhSach();
            string congTy = string.Empty;
            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhSach[i].MaHang == maHang)
                {
                    congTy = danhSach[i].CongTySanXuat;
                    return congTy;
                }
            }
            return congTy;
        }
        public static DateOnly LayNgaySanXuat(string maHang)
        {
            MatHang[] danhSach = DocDanhSach();
            DateOnly ngaySanXuat;
            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhSach[i].MaHang == maHang)
                {
                    ngaySanXuat = danhSach[i].NgaySanXuat;
                    return ngaySanXuat;
                }
            }
            return ngaySanXuat;
        }
        public static DateOnly LayHanDung(string maHang)
        {
            MatHang[] danhSach = DocDanhSach();
            DateOnly hanDung;
            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhSach[i].MaHang == maHang)
                {
                    hanDung = danhSach[i].HanDung;
                    return hanDung;
                }
            }
            return hanDung;
        }
        public static int LaySoLuongTonKho(string maHang)
        {
            MatHangTonKho[] danhSach = DocDanhSachTonKho();
            int soLuongTonKho = 0;
            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhSach[i].MaHang == maHang)
                {
                    soLuongTonKho = danhSach[i].SoLuongTonKho;
                    return soLuongTonKho;
                }
            }
            return soLuongTonKho;
        }
    }
}
