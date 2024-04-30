using Entities;

namespace Services;
public interface IXuLyLoaiHang
{
    List<LoaiHang> DocDanhSachLoaiHang(string timKiemTheo, string tuKhoa = "");
    void ThemLoaiHang(LoaiHang loaiHang);
    void XoaLoaiHang(int maLoaiHang);
    List<string> DocDanhSachTenLoaiHang();
    LoaiHang DocThongTinLoaiHang(int maLoaiHang);
    void SuaLoaiHang(LoaiHang loaiHang);
    bool KiemTraMaLoaiHang(int maLoaiHang);
}