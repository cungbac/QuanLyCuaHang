using System;
using Entities;
using Repo;

namespace Services
{
	public class XuLyMatHang : IXuLyMatHang
	{
		private ILuuTruMatHang _luuTruMatHang = new LuuTruMatHang();

		public List<MatHang> DocDanhSachMatHang(string tuKhoa = "")
		{
			List<MatHang> kq = new List<MatHang>();
			var dsMatHang = _luuTruMatHang.DocDanhSachMatHang();

			foreach(var matHang in dsMatHang)
			{
				if (matHang.TenHang.Contains(tuKhoa))
				{
					kq.Add(matHang);
				}
			}

			return kq;
		}
		public void ThemMatHang(MatHang matHang)
		{
			var dsMatHang = _luuTruMatHang.DocDanhSachMatHang();
			int maxId = 0;

			foreach(var mh in dsMatHang)
			{
				if (mh.MaHang > maxId)
				{
					maxId = mh.MaHang;
				}
			}
			matHang.MaHang = maxId + 1;

			_luuTruMatHang.ThemMatHang(matHang);
		}
		public void XoaMatHang(MatHang matHang)
		{
			_luuTruMatHang.XoaMatHang(matHang);
		}
	}
}

