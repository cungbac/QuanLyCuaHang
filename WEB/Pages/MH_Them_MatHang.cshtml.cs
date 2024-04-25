using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using Services;

namespace WEB.Pages
{
    public class MH_Them_MatHang : PageModel
    {
        private IXuLyMatHang _xuLyMatHang = new XuLyMatHang();
        private IXuLyLoaiHang _xuLyLoaiHang = new XuLyLoaiHang();

        public List<MatHang> dsMatHang;
        public string message;
        public List<string> dsLoaiHang;

        [BindProperty]
        public string tenHang { get; set; }

        [BindProperty]
        public string hanDung { get; set; }

        [BindProperty]
        public string congTySanXuat { get; set; }

        [BindProperty]
        public string ngaySanXuat { get; set; }

        [BindProperty]
        public string loaiHang { get; set; }

        [BindProperty]
        public double giaBan { get; set; }

        public void OnGet()
        {
            dsLoaiHang = _xuLyLoaiHang.DocDanhSachTenLoaiHang();
        }
        public void OnPost()
        {
            try
            {
                dsLoaiHang = _xuLyLoaiHang.DocDanhSachTenLoaiHang();
                var matHang = new MatHang(tenHang, hanDung, congTySanXuat, ngaySanXuat, loaiHang, giaBan);
                _xuLyMatHang.ThemMatHang(matHang);
                message = "Successful";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }
    }
}

