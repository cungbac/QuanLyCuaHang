using Entities;

namespace Services;
public interface IXuLyMatHang
{
    List<MatHang> DocDanhSachMatHang(string tuKhoa);
    void ThemMatHang(MatHang matHang);
    void XoaMatHang(MatHang matHang);
}