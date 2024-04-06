namespace QuanLyCuaHang.Entities
{
    public struct MatHang
    {
        public string MaHang;
        public string TenHang;
        public DateOnly HanDung;
        public string CongTySanXuat;
        public DateOnly NgaySanXuat;
        public string LoaiHang;
        public double GiaBan;
    }
    public struct MatHangTonKho
    {
        public string MaHang;
        public string TenHang;
        public DateOnly HanDung;
        public string CongTySanXuat;
        public DateOnly NgaySanXuat;
        public string LoaiHang;
        public int SoLuongTonKho;
    }
}
