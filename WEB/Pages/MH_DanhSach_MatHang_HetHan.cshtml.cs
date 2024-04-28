using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using Services;

namespace WEB.Pages
{
    public class MH_DanhSach_MatHang_HetHan : PageModel
    {
        private IXuLyMatHang _xuLyMatHang = new XuLyMatHang();
        public List<MatHang> dsMatHang = new List<MatHang>();

        public int totalItems { get; set; }

        [BindProperty]
        public string timKiemTheo { get; set; }

        [BindProperty]
        public string tuKhoa { get; set; }

        public void OnGet()
        {
            dsMatHang = _xuLyMatHang.DocDanhSachMatHangHetHan(timKiemTheo = "tenhang", tuKhoa = "");
            totalItems = dsMatHang.Count();
        }
        public void OnPost()
        {
            dsMatHang = _xuLyMatHang.DocDanhSachMatHangHetHan(timKiemTheo = timKiemTheo, tuKhoa = tuKhoa);
            totalItems = dsMatHang.Count();
        }
    }
}

