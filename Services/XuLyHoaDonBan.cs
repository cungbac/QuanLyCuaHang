using System;
using Entities;
using Repo;

namespace Services
{
    public class XuLyHoaDonBan : IXuLyHoaDonBan
    {
        private ILuuTruHoaDonBan _luuTruHoaDonBan = new LuuTruHoaDonBan();

        public List<HoaDonBanHang> DocDanhSachHoaDonBan(string tuKhoa = "")
        {
            List<HoaDonBanHang> kq = new List<HoaDonBanHang>();
            var dsHoaDonBan = _luuTruHoaDonBan.DocDanhSachHoaDonBan();

            foreach (var hoaDonBan in dsHoaDonBan)
            {
                if (hoaDonBan.TenHang.Contains(tuKhoa))
                {
                    kq.Add(hoaDonBan);
                }
            }

            return kq;
        }
        public void ThemHoaDonBan(HoaDonBanHang hoaDonBan)
        {
            var dsHoaDonBan = _luuTruHoaDonBan.DocDanhSachHoaDonBan();
            int maxId = 0;

            foreach (var mhd in dsHoaDonBan)
            {
                if (mhd.MaHoaDon > maxId)
                {
                    maxId = mhd.MaHoaDon;
                }
            }
            hoaDonBan.MaHoaDon = maxId + 1;

            _luuTruHoaDonBan.ThemHoaDonBan(hoaDonBan);
        }
        public void XoaHoaDonBan(HoaDonBanHang hoaDonBan)
        {
            _luuTruHoaDonBan.XoaHoaDonBan(hoaDonBan);
        }
    }
}

