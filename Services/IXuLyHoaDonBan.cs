using Entities;

namespace Services;
public interface IXuLyHoaDonBan
{
    List<HoaDonBanHang> DocDanhSachHoaDonBan(string timKiemTheo, string tuKhoa = "");
    void ThemHoaDonBan(HoaDonBanHang hoaDonBan);
    void XoaHoaDonBan(int maHoaDon);
    void SuaHoaDonBan(HoaDonBanHang hoaDonBan);
    HoaDonBanHang DocThongTinHoaDon(int maHoaDon);
    bool KiemTraMaHoaDon(int maHoaDon);
}