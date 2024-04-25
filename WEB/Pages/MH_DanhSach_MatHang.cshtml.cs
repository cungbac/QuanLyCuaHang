using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using Services;

namespace WEB.Pages
{
    public class MH_DanhSach_MatHang : PageModel
    {
        private IXuLyMatHang _xuLyMatHang = new XuLyMatHang();
        public List<MatHang> dsMatHang;

        public int totalItems { get; set; }

        [BindProperty]
        public string tuKhoa { get; set; }

        public void OnGet()
        {
            dsMatHang = _xuLyMatHang.DocDanhSachMatHang("");
            totalItems = dsMatHang.Count();   
        }
        public void OnPost()
        {
            dsMatHang = _xuLyMatHang.DocDanhSachMatHang(tuKhoa);
            totalItems = dsMatHang.Count();
        }
    }
}

