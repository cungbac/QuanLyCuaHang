using Entities;

namespace Services;
public interface IXuLyLoaiHang
{
    List<LoaiHang> DocDanhSachLoaiHang(string tuKhoa);
    void ThemLoaiHang(LoaiHang loaiHang);
    void XoaLoaiHang(LoaiHang loaiHang);
    List<string> DocDanhSachTenLoaiHang();
}