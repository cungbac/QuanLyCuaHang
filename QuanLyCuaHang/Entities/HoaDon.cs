namespace QuanLyCuaHang.Entities
{
    public struct HoaDonBanHang
    {
        public string MaHoaDon;
        public DateOnly NgayTao;
        public string MaHang;
        public string TenHang;
        public int SoLuong;
        public double GiaBan;
        public double ThanhTien;
    }
    public struct HoaDonNhapHang
    {
        public string MaHoaDon;
        public DateOnly NgayTao;
        public string MaHang;
        public string TenHang;
        public int SoLuong;
        public double GiaNhap;
        public double ThanhTien;
    }
}
