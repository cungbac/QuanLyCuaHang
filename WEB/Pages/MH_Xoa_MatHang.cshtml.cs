using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using Services;

namespace WEB.Pages
{
    public class MH_Xoa_MatHang : PageModel
    {
        private IXuLyMatHang _xuLyMatHang = new XuLyMatHang();

        public MatHang matHang;
        public string message;
        public int maHang;

        public void OnGet()
        {
            try
            {
                maHang = int.Parse(Request.Query["mahang"]);
                matHang = _xuLyMatHang.DocThongTinMatHang(maHang);
            }
            catch
            {
                message = "Mặt hàng không tồn tại!";
            }
        }
        public void OnPost()
        {
            try
            {
                maHang = int.Parse(Request.Query["mahang"]);
                matHang = _xuLyMatHang.DocThongTinMatHang(maHang);
                _xuLyMatHang.XoaMatHang(maHang);
                message = "Successful";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }
    }
}

