using Entities;

namespace Services;
public interface IXuLyHoaDonNhap
{
    List<HoaDonNhapHang> DocDanhSachHoaDonNhap(string timKiemTheo, string tuKhoa = "");
    void ThemHoaDonNhap(HoaDonNhapHang hoaDonNhap);
    void XoaHoaDonNhap(int maHoaDon);
    void SuaHoaDonNhap(HoaDonNhapHang hoaDonNhap);
    HoaDonNhapHang DocThongTinHoaDon(int maHoaDon);
    bool KiemTraMaHoaDon(int maHoaDon);
}