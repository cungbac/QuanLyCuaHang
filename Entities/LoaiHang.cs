using System;
using System.Reflection.PortableExecutable;

namespace Entities
{
	public class LoaiHang
	{
        public int MaLoaiHang { get; set; }
        public string TenLoaiHang { get; set; }

        public LoaiHang(string tenLoaiHang)
        {
            if (string.IsNullOrEmpty(tenLoaiHang))
            {
                throw new Exception("Tên loại hàng không được để trống!");
            }
            this.TenLoaiHang = tenLoaiHang;
        }

        public LoaiHang(string[] m)
        {
            this.MaLoaiHang = int.Parse(m[0]);
            this.TenLoaiHang = m[1];
        }
    }
}

