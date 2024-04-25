﻿using System;
namespace Entities
{
	public class HoaDonNhapHang
	{
        public int MaHoaDon { get; set; }
        public DateOnly NgayTao { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public int SoLuong { get; set; }
        public double GiaNhap { get; set; }
        public double ThanhTien { get; set; }

        public HoaDonNhapHang(string s)
        {
            string[] m = s.Split(",");
            this.MaHoaDon = int.Parse(m[0]);
            this.NgayTao = DateOnly.Parse(m[1]);
            this.MaHang = m[2];
            this.TenHang = m[3];
            this.SoLuong = int.Parse(m[4]);
            this.GiaNhap = double.Parse(m[5]);
            this.ThanhTien = double.Parse(m[6]);
        }
    }
}

