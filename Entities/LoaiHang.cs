using System;
using System.Reflection.PortableExecutable;

namespace Entities
{
	public class LoaiHang
	{
        public int MaLoaiHang { get; set; }
        public string TenLoaiHang { get; set; }

        public LoaiHang(string s)
        {
            string[] m = s.Split(",");
            this.MaLoaiHang = int.Parse(m[0]);
            this.TenLoaiHang = m[1];
        }
    }
}

