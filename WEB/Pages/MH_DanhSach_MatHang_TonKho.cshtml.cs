using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using Services;

namespace WEB.Pages
{
    public class MH_DanhSach_MatHang_TonKho : PageModel
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
            dsMatHang = _xuLyMatHang.DocDanhSachMatHangTonKho(timKiemTheo = "tenhang", tuKhoa = "");
            totalItems = dsMatHang.Count();
        }
        public void OnPost()
        {
            dsMatHang = _xuLyMatHang.DocDanhSachMatHangTonKho(timKiemTheo = timKiemTheo, tuKhoa = tuKhoa);
            totalItems = dsMatHang.Count();
        }
    }
}

