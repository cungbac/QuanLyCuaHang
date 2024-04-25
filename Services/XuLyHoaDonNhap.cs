using System;
using Entities;
using Repo;

namespace Services
{
    public class XuLyHoaDonNhap : IXuLyHoaDonNhap
    {
        private ILuuTruHoaDonNhap _luuTruHoaDonNhap = new LuuTruHoaDonNhap();

        public List<HoaDonNhapHang> DocDanhSachHoaDonNhap(string tuKhoa = "")
        {
            List<HoaDonNhapHang> kq = new List<HoaDonNhapHang>();
            var dsHoaDonNhap = _luuTruHoaDonNhap.DocDanhSachHoaDonNhap();

            foreach (var hoaDonNhap in dsHoaDonNhap)
            {
                if (hoaDonNhap.TenHang.Contains(tuKhoa))
                {
                    kq.Add(hoaDonNhap);
                }
            }

            return kq;
        }
        public void ThemHoaDonNhap(HoaDonNhapHang hoaDonNhap)
        {
            var dsHoaDonNhap = _luuTruHoaDonNhap.DocDanhSachHoaDonNhap();
            int maxId = 0;

            foreach (var mhd in dsHoaDonNhap)
            {
                if (mhd.MaHoaDon > maxId)
                {
                    maxId = mhd.MaHoaDon;
                }
            }
            hoaDonNhap.MaHoaDon = maxId + 1;

            _luuTruHoaDonNhap.ThemHoaDonNhap(hoaDonNhap);
        }
        public void XoaHoaDonNhap(HoaDonNhapHang hoaDonNhap)
        {
            _luuTruHoaDonNhap.XoaHoaDonNhap(hoaDonNhap);
        }
    }
}

