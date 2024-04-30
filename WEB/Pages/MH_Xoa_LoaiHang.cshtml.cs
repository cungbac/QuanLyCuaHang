using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using Services;

namespace WEB.Pages
{
    public class MH_Xoa_LoaiHang : PageModel
    {
        private IXuLyLoaiHang _xuLyLoaiHang = new XuLyLoaiHang();

        public LoaiHang loaiHang;
        public string message;
        public int maLoaiHang;

        public void OnGet()
        {
            try
            {
                maLoaiHang = int.Parse(Request.Query["maloaihang"]);
                loaiHang = _xuLyLoaiHang.DocThongTinLoaiHang(maLoaiHang);
            }
            catch
            {
                message = "Loại hàng không tồn tại!";
            }
        }
        public void OnPost()
        {
            try
            {
                maLoaiHang = int.Parse(Request.Query["maloaihang"]);
                loaiHang = _xuLyLoaiHang.DocThongTinLoaiHang(maLoaiHang);
                _xuLyLoaiHang.XoaLoaiHang(maLoaiHang);
                message = "Successful";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }
    }
}

