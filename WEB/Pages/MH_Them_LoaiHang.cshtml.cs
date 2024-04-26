using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using Services;

namespace WEB.Pages
{
    public class MH_Them_LoaiHang : PageModel
    {
        private IXuLyLoaiHang _xuLyLoaiHang = new XuLyLoaiHang();

        public List<LoaiHang> dsLoaiHang;
        public string message;

        [BindProperty]
        public string tenLoaiHang { get; set; }

        public void OnGet()
        {
        }
        public void OnPost()
        {
            try
            {
                var loaiHang = new LoaiHang(tenLoaiHang);
                _xuLyLoaiHang.ThemLoaiHang(loaiHang);
                message = "Successful";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }
    }
}

