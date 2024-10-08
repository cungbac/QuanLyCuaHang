﻿using System;
using Entities;
using Repo;

namespace Services
{
    public class XuLyLoaiHang : IXuLyLoaiHang
    {
        private ILuuTruLoaiHang _luuTruLoaiHang = new LuuTruLoaiHang();

        public List<LoaiHang> DocDanhSachLoaiHang(string timKiemTheo = "tenloaihang", string tuKhoa = "")
        {
            List<LoaiHang> kq = new List<LoaiHang>();
            var dsLoaiHang = _luuTruLoaiHang.DocDanhSachLoaiHang();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                tuKhoa = "";
            }

            if (timKiemTheo == "maloaihang")
            {
                foreach (var loaiHang in dsLoaiHang)
                {
                    if (loaiHang.MaLoaiHang == int.Parse(tuKhoa))
                    {
                        kq.Add(loaiHang);
                    }
                }
            }
            else
            {
                foreach (var loaiHang in dsLoaiHang)
                {
                    if (loaiHang.TenLoaiHang.Contains(tuKhoa))
                    {
                        kq.Add(loaiHang);
                    }
                }
            }
 
            return kq;
        }
        public void ThemLoaiHang(LoaiHang loaiHang)
        {
            var dsLoaiHang = _luuTruLoaiHang.DocDanhSachLoaiHang();
            int maxId = 0;

            foreach (var mlh in dsLoaiHang)
            {
                if (mlh.MaLoaiHang > maxId)
                {
                    maxId = mlh.MaLoaiHang;
                }
            }
            loaiHang.MaLoaiHang = maxId + 1;

            _luuTruLoaiHang.ThemLoaiHang(loaiHang);
        }
        public void XoaLoaiHang(int maLoaiHang)
        {
            _luuTruLoaiHang.XoaLoaiHang(maLoaiHang);
        }
        public List<string> DocDanhSachTenLoaiHang()
        {
            List<string> dsTenLoaiHang = new List<string>();
            var dsLoaiHang = DocDanhSachLoaiHang();
            foreach(var loaiHang in dsLoaiHang)
            {
                dsTenLoaiHang.Add(loaiHang.TenLoaiHang);
            }
            return dsTenLoaiHang;
        }
        public LoaiHang? DocThongTinLoaiHang(int maLoaiHang)
        {
            LoaiHang kq = _luuTruLoaiHang.DocThongTinLoaiHang(maLoaiHang);
            return kq;
        }
        public void SuaLoaiHang(LoaiHang loaiHang)
        {
            _luuTruLoaiHang.SuaLoaiHang(loaiHang);
        }
        public bool KiemTraMaLoaiHang(int maLoaiHang)
        {
            return _luuTruLoaiHang.KiemTraMaLoaiHang(maLoaiHang);
        }
    }
}

