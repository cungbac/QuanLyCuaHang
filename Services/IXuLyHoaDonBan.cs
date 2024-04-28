﻿using Entities;

namespace Services;
public interface IXuLyHoaDonBan
{
    List<HoaDonBanHang> DocDanhSachHoaDonBan(string timKiemTheo, string tuKhoa = "");
    void ThemHoaDonBan(HoaDonBanHang hoaDonBan);
    void XoaHoaDonBan(HoaDonBanHang hoaDonBan);
    void SuaHoaDonBan(HoaDonBanHang hoaDonBan);
    HoaDonBanHang DocThongTinHoaDon(int maHoaDon);
}