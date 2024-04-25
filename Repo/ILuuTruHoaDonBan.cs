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
        void XoaHoaDonBan(HoaDonBanHang hoaDonBan);
    }
}

