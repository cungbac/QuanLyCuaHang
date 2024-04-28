using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using Services;

namespace WEB.Pages
{
    public class MH_Sua_LoaiHang : PageModel
    {
        private IXuLyLoaiHang _xuLyLoaiHang = new XuLyLoaiHang();

        public LoaiHang loaiHang;
        public string message;
        public int maLoaiHang;

        [BindProperty]
        public string tenLoaiHang { get; set; }

        public void OnGet()
        {
            maLoaiHang = int.Parse(Request.Query["maloaihang"]);
            loaiHang = _xuLyLoaiHang.DocThongTinLoaiHang(maLoaiHang);
        }
        public void OnPost()
        {
            try
            {
                maLoaiHang = int.Parse(Request.Query["maloaihang"]);
                loaiHang = _xuLyLoaiHang.DocThongTinLoaiHang(maLoaiHang);
                var loaiHangMoi = new LoaiHang(tenLoaiHang);
                loaiHangMoi.MaLoaiHang = maLoaiHang;
                _xuLyLoaiHang.SuaLoaiHang(loaiHangMoi);
                message = "Successful";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }
    }
}

