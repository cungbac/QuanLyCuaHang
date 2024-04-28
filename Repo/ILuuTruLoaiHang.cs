using System;
using Entities;

namespace Repo
{
	public interface ILuuTruLoaiHang
	{
		string GetFilePath();
		List<LoaiHang> DocDanhSachLoaiHang();
		void LuuDanhSachLoaiHang(List<LoaiHang> dsLoaiHang);
		void ThemLoaiHang(LoaiHang loaiHang);
        void XoaLoaiHang(LoaiHang loaiHang);
		void SuaLoaiHang(LoaiHang loaiHang);
		LoaiHang DocThongTinLoaiHang(int maLoaiHang);
    }
}

