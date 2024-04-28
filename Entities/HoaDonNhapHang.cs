using System;
namespace Entities
{
	public class HoaDonNhapHang
	{
        public int MaHoaDon { get; set; }
        public string NgayTao { get; set; }
        public string NgayCapNhat { get; set; }
        public int MaHang { get; set; }
        public string TenHang { get; set; }
        public int SoLuong { get; set; }
        public double GiaNhap { get; set; }
        public double ThanhTien { get; set; }

        public HoaDonNhapHang(string ngayTao, string ngayCapNhat, int maHang, string tenHang, int soLuong, double giaNhap)
        {
            if (soLuong <= 0)
            {
                throw new Exception("Số lượng không hợp lệ!");
            }
            if (giaNhap < 0)
            {
                throw new Exception("Giá nhập không hợp lệ!");
            }

            this.NgayTao = ngayTao;
            this.NgayCapNhat = ngayCapNhat;
            this.MaHang = maHang;
            this.TenHang = tenHang;
            this.SoLuong = soLuong;
            this.GiaNhap = giaNhap;
            this.ThanhTien = soLuong * giaNhap;
        }

        public HoaDonNhapHang(string s)
        {
            string[] m = s.Split(",");
            this.MaHoaDon = int.Parse(m[0]);
            this.NgayTao = m[1];
            this.NgayCapNhat = m[2];
            this.MaHang = int.Parse(m[3]);
            this.TenHang = m[4];
            this.SoLuong = int.Parse(m[5]);
            this.GiaNhap = double.Parse(m[6]);
            this.ThanhTien = double.Parse(m[7]);
        }
    }
}

