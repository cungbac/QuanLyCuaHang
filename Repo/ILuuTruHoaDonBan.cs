using System;
using Entities;

namespace Repo
{
    public interface ILuuTruHoaDonBan
    {
        string GetFilePath();
        List<HoaDonBanHang> DocDanhSachHoaDonBan();
        void LuuDanhSachHoaDonBan(List<HoaDonBanHang> dsHoaDonBan);
        void ThemHoaDonBan(HoaDonBanHang hoaDonBan);
        void XoaHoaDonBan(int maHoaDon);
        void SuaHoaDonBan(HoaDonBanHang maHoaDon);
        HoaDonBanHang DocThongTinHoaDon(int maHoaDon);
        bool KiemTraMaHoaDon(int maHoaDon);
    }
}

