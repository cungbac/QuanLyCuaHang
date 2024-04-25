using Entities;

namespace Repo;
public interface ILuuTruMatHang
{
    string GetFilePath();
    List<MatHang> DocDanhSachMatHang();
    void LuuDanhSachMatHang(List<MatHang> dsMatHang);
    void ThemMatHang(MatHang matHang);
    void XoaMatHang(MatHang matHang);
}

