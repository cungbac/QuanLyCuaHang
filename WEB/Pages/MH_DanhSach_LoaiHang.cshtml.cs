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
        public string chuoi;

        [BindProperty]
        public string tuKhoa { get; set; }

        public void OnGet()
        {
            dsLoaiHang = _xuLyLoaiHang.DocDanhSachLoaiHang("");
        }
        public void OnPost()
        {
            dsLoaiHang = _xuLyLoaiHang.DocDanhSachLoaiHang(tuKhoa);
        }
    }
}

