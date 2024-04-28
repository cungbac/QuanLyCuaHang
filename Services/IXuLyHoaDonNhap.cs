using Entities;

namespace Services;
public interface IXuLyHoaDonNhap
{
    List<HoaDonNhapHang> DocDanhSachHoaDonNhap(string timKiemTheo, string tuKhoa = "");
    void ThemHoaDonNhap(HoaDonNhapHang hoaDonNhap);
    void XoaHoaDonNhap(HoaDonNhapHang hoaDonNhap);
    void SuaHoaDonNhap(HoaDonNhapHang hoaDonNhap);
    HoaDonNhapHang DocThongTinHoaDon(int maHoaDon);
}