﻿using Entities;

namespace Services;
public interface IXuLyHoaDonBan
{
    List<HoaDonBanHang> DocDanhSachHoaDonBan(string tuKhoa);
    void ThemHoaDonBan(HoaDonBanHang hoaDonBan);
    void XoaHoaDonBan(HoaDonBanHang hoaDonBan);
}