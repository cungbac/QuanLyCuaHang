using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using Services;

namespace WEB.Pages
{
    public class MH_DanhSach_LoaiHang : PageModel
    {
        private IXuLyLoaiHang _xuLyLoaiHang = new XuLyLoaiHang();
        public List<LoaiHang> dsLoaiHang;

        public int totalItems { get; set; }

        [BindProperty]
        public string timKiemTheo { get; set; }

        [BindProperty]
        public string tuKhoa { get; set; }

        public void OnGet()
        {
            dsLoaiHang = _xuLyLoaiHang.DocDanhSachLoaiHang(timKiemTheo = "tenloaihang", "");
            totalItems = dsLoaiHang.Count();
        }
        public void OnPost()
        {
            dsLoaiHang = _xuLyLoaiHang.DocDanhSachLoaiHang(tuKhoa);
            totalItems = dsLoaiHang.Count();
        }
    }
}

