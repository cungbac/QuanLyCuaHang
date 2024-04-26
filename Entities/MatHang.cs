namespace Entities;

public class MatHang
{
    public int MaHang { get; set; }
    public string TenHang { get; set; }
    public string HanDung { get; set; }
    public string CongTySanXuat { get; set; }
    public string NgaySanXuat { get; set; }
    public string LoaiHang { get; set; }
    public double GiaBan { get; set; }
    public int SoLuongTonKho { get; set; }

    public MatHang(string tenHang, string hanDung, string congTySanXuat, string ngaySanXuat, string loaiHang, double giaBan, int tonKho=0)
    {
        if (string.IsNullOrEmpty(tenHang))
        {
            throw new Exception("Tên mặt hàng không được để trống!");
        }
        if (string.IsNullOrEmpty(congTySanXuat))
        {
            throw new Exception("Tên công ty không được để trống!");
        }
        if (giaBan < 0)
        {
            throw new Exception("Giá bán không hợp lệ!");
        }
        if (DateOnly.Parse(hanDung) < DateOnly.Parse(ngaySanXuat))
        {
            throw new Exception("Hạn sử dụng nhỏ hơn ngày sản xuất!");
        }
        if (giaBan < 0)
        {
            throw new Exception("Giá bán không hợp lệ!");
        }

        this.TenHang = tenHang;
        this.HanDung = hanDung;
        this.CongTySanXuat = congTySanXuat;
        this.NgaySanXuat = ngaySanXuat;
        this.LoaiHang = loaiHang;
        this.GiaBan = giaBan;
        this.SoLuongTonKho = tonKho;
    }
    public MatHang(string s)
    {
        string[] m = s.Split(',');
        this.MaHang = int.Parse(m[0]);
        this.TenHang = m[1];
        this.HanDung = m[2];
        this.CongTySanXuat = m[3];
        this.NgaySanXuat = m[4];
        this.LoaiHang = m[5];
        this.GiaBan = int.Parse(m[6]);
        this.SoLuongTonKho = int.Parse(m[7]);
    }
}