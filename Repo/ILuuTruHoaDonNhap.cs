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
        void XoaHoaDonNhap(HoaDonNhapHang hoaDonNhap);
    }
}

