using System;
using Entities;
using Repo;

namespace Services
{
	public class XuLyMatHang : IXuLyMatHang
	{
		private ILuuTruMatHang _luuTruMatHang = new LuuTruMatHang();

		public List<MatHang> DocDanhSachMatHang(string timKiemTheo = "tenhang", string tuKhoa = "")
		{
			List<MatHang> kq = new List<MatHang>();
			var dsMatHang = _luuTruMatHang.DocDanhSachMatHang();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                tuKhoa = "";
            }

			if (timKiemTheo == "mahang")
			{
                foreach (var matHang in dsMatHang)
                {
                    if (matHang.MaHang == int.Parse(tuKhoa))
                    {
                        kq.Add(matHang);
                    }
                }
            }
            else if (timKiemTheo == "loaihang")
            {
                foreach (var matHang in dsMatHang)
                {
                    if (matHang.LoaiHang.Contains(tuKhoa))
                    {
                        kq.Add(matHang);
                    }
                }
            }
            else if (timKiemTheo == "congtysanxuat")
			{
                foreach (var matHang in dsMatHang)
                {
                    if (matHang.CongTySanXuat.Contains(tuKhoa))
                    {
                        kq.Add(matHang);
                    }
                }
            }
			else
			{
                foreach (var matHang in dsMatHang)
                {
                    if (matHang.TenHang.Contains(tuKhoa))
                    {
                        kq.Add(matHang);
                    }
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
		public void XoaMatHang(int maHang)
		{
			_luuTruMatHang.XoaMatHang(maHang);
		}
        public MatHang? DocThongTinMatHang(int maHang)
        {
            MatHang? kq = _luuTruMatHang.DocThongTinMatHang(maHang);
            
            return kq;
        }
		public string DocTenMatHang(int maHang)
		{
			string kq = string.Empty;
			var dsMatHang = DocDanhSachMatHang();
			foreach(var matHang in dsMatHang)
			{
				if (matHang.MaHang == maHang)
				{
					kq = matHang.TenHang;
					break;
				}
			}
			return kq;
		}
		public bool KiemTraMaHang(int maHang)
		{
            return _luuTruMatHang.KiemTraMaHang(maHang);
        }
        public List<MatHang> DocDanhSachMatHangTonKho(string timKiemTheo = "tenhang", string tuKhoa = "")
        {
            List<MatHang> dsTonKho = new List<MatHang>();
            List<MatHang> kq = new List<MatHang>();
            var dsMatHang = _luuTruMatHang.DocDanhSachMatHang();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                tuKhoa = "";
            }

            foreach (var matHang in dsMatHang)
            {
                if (matHang.SoLuongTonKho > 0)
                {
                    dsTonKho.Add(matHang);
                }
            }

            if (timKiemTheo == "mahang")
            {
                foreach (var matHang in dsTonKho)
                {
                    if (matHang.MaHang == int.Parse(tuKhoa))
                    {
                        kq.Add(matHang);
                    }
                }
            }
            else if (timKiemTheo == "loaihang")
            {
                foreach (var matHang in dsTonKho)
                {
                    if (matHang.LoaiHang.Contains(tuKhoa))
                    {
                        kq.Add(matHang);
                    }
                }
            }
            else if (timKiemTheo == "congtysanxuat")
            {
                foreach (var matHang in dsTonKho)
                {
                    if (matHang.CongTySanXuat.Contains(tuKhoa))
                    {
                        kq.Add(matHang);
                    }
                }
            }
            else
            {
                foreach (var matHang in dsTonKho)
                {
                    if (matHang.TenHang.Contains(tuKhoa))
                    {
                        kq.Add(matHang);
                    }
                }
            }

            return kq;
        }
        public List<MatHang> DocDanhSachMatHangHetHan(string timKiemTheo = "tenhang", string tuKhoa = "")
        {
            List<MatHang> dsHetHan = new List<MatHang>();
            List<MatHang> kq = new List<MatHang>();
            var dsMatHang = _luuTruMatHang.DocDanhSachMatHang();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                tuKhoa = "";
            }

            foreach (var matHang in dsMatHang)
            {
                if (DateTime.Parse(matHang.HanDung).Date < DateTime.Today && matHang.SoLuongTonKho > 0)
                {
                    dsHetHan.Add(matHang);
                }
            }

            if (timKiemTheo == "mahang")
            {
                foreach (var matHang in dsHetHan)
                {
                    if (matHang.MaHang == int.Parse(tuKhoa))
                    {
                        kq.Add(matHang);
                    }
                }
            }
            else if (timKiemTheo == "loaihang")
            {
                foreach (var matHang in dsHetHan)
                {
                    if (matHang.LoaiHang.Contains(tuKhoa))
                    {
                        kq.Add(matHang);
                    }
                }
            }
            else if (timKiemTheo == "congtysanxuat")
            {
                foreach (var matHang in dsHetHan)
                {
                    if (matHang.CongTySanXuat.Contains(tuKhoa))
                    {
                        kq.Add(matHang);
                    }
                }
            }
            else
            {
                foreach (var matHang in dsHetHan)
                {
                    if (matHang.TenHang.Contains(tuKhoa))
                    {
                        kq.Add(matHang);
                    }
                }
            }

            return kq;
        }
        public int DocSoLuongTonKho(int maHang)
		{
            int kq = 0;
            var dsMatHang = DocDanhSachMatHang();
            foreach (var matHang in dsMatHang)
            {
                if (matHang.MaHang == maHang)
                {
                    kq = matHang.SoLuongTonKho;
                    break;
                }
            }
            return kq;
        }
		public void CapNhatTonKho(int maHang, int soLuong)
		{
			_luuTruMatHang.CapNhatTonKho(maHang, soLuong);
		}
        public void SuaMatHang(MatHang matHang)
        {
            _luuTruMatHang.SuaMatHang(matHang);
        }
	}
}

