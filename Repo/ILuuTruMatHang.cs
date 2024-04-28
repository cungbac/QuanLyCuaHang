using Entities;

namespace Repo;
public interface ILuuTruMatHang
{
    string GetFilePath();
    List<MatHang> DocDanhSachMatHang();
    void LuuDanhSachMatHang(List<MatHang> dsMatHang);
    void ThemMatHang(MatHang matHang);
    void XoaMatHang(MatHang matHang);
    void CapNhatTonKho(int maHang, int soLuong);
    void SuaMatHang(MatHang matHang);
    MatHang DocThongTinMatHang(int maHang);
}

