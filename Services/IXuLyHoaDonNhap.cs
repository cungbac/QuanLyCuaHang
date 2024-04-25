using Entities;

namespace Services;
public interface IXuLyHoaDonNhap
{
    List<HoaDonNhapHang> DocDanhSachHoaDonNhap(string tuKhoa);
    void ThemHoaDonNhap(HoaDonNhapHang hoaDonNhap);
    void XoaHoaDonNhap(HoaDonNhapHang hoaDonNhap);
}