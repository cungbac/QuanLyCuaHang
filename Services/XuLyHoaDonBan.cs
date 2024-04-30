using System;
using Entities;
using Repo;

namespace Services
{
    public class XuLyHoaDonBan : IXuLyHoaDonBan
    {
        private ILuuTruHoaDonBan _luuTruHoaDonBan = new LuuTruHoaDonBan();

        public List<HoaDonBanHang> DocDanhSachHoaDonBan(string timKiemTheo, string tuKhoa = "")
        {
            List<HoaDonBanHang> kq = new List<HoaDonBanHang>();
            var dsHoaDonBan = _luuTruHoaDonBan.DocDanhSachHoaDonBan();

            if (timKiemTheo == "mahoadon")
            {
                foreach (var hoaDonBan in dsHoaDonBan)
                {
                    if (hoaDonBan.MaHoaDon == int.Parse(tuKhoa))
                    {
                        kq.Add(hoaDonBan);
                    }
                }
            }
            else if (timKiemTheo == "mahang")
            {
                foreach (var hoaDonBan in dsHoaDonBan)
                {
                    if (hoaDonBan.MaHang == int.Parse(tuKhoa))
                    {
                        kq.Add(hoaDonBan);
                    }
                }
            }
            else
            {
                foreach (var hoaDonBan in dsHoaDonBan)
                {
                    if (hoaDonBan.TenHang.Contains(tuKhoa))
                    {
                        kq.Add(hoaDonBan);
                    }
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
        public void XoaHoaDonBan(int maHoaDon)
        {
            _luuTruHoaDonBan.XoaHoaDonBan(maHoaDon);
        }
        public void SuaHoaDonBan(HoaDonBanHang hoaDonBan)
        {
            _luuTruHoaDonBan.SuaHoaDonBan(hoaDonBan);
        }
        public HoaDonBanHang? DocThongTinHoaDon(int maHoaDon)
        {
            HoaDonBanHang? kq = _luuTruHoaDonBan.DocThongTinHoaDon(maHoaDon);
            return kq;
        }
        public bool KiemTraMaHoaDon(int maHoaDon)
        {
            return _luuTruHoaDonBan.KiemTraMaHoaDon(maHoaDon);
        }
    }
}

