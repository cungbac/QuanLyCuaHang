using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using Services;

namespace WEB.Pages
{
    public class MH_DanhSach_MatHang_HetHan : PageModel
    {
        private IXuLyMatHang _xuLyMatHang = new XuLyMatHang();
        public List<MatHang> dsMatHang;
        public string chuoi;

        [BindProperty]
        public string tuKhoa { get; set; }

        public void OnGet()
        {
            dsMatHang = _xuLyMatHang.DocDanhSachMatHang("");
        }
        public void OnPost()
        {
            dsMatHang = _xuLyMatHang.DocDanhSachMatHang(tuKhoa);
        }
    }
}

