using System;
using Entities;

namespace Repo
{
    public interface ILuuTruHoaDonNhap
    {
        string GetFilePath();
        List<HoaDonNhapHang> DocDanhSachHoaDonNhap();
        void LuuDanhSachHoaDonNhap(List<HoaDonNhapHang> dsHoaDonNhap);
        void ThemHoaDonNhap(HoaDonNhapHang hoaDonNhap);
        void XoaHoaDonNhap(int maHoaDon);
        void SuaHoaDonNhap(HoaDonNhapHang maHoaDon);
        HoaDonNhapHang DocThongTinHoaDon(int maHoaDon);
        bool KiemTraMaHoaDon(int maHoaDon);
    }
}

