using Entities;

namespace Services;
public interface IXuLyMatHang
{
    List<MatHang> DocDanhSachMatHang(string timKiemTheo, string tuKhoa = "");
    List<MatHang> DocDanhSachMatHangTonKho(string timKiemTheo = "tenhang", string tuKhoa = "");
    void ThemMatHang(MatHang matHang);
    void XoaMatHang(MatHang matHang);
    string DocTenMatHang(int maHang);
    bool KiemTraMaHang(int maHang);
    int DocSoLuongTonKho(int maHang);
    void CapNhatTonKho(int maHang, int soLuong);
}