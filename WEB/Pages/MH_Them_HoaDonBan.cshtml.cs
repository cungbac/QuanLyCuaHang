using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using Services;

namespace WEB.Pages
{
    public class MH_Them_HoaDonBan : PageModel
    {
        private IXuLyHoaDonBan _xuLyHoaDonBan = new XuLyHoaDonBan();
        private IXuLyMatHang _xuLyMatHang = new XuLyMatHang();

        public List<MatHang> dsMatHang;
        public string message;
        public string tenHang;
        public bool kiemTraMaHang;
        public int soLuongTonKhoHienTai;
        public int soLuongTonKhoMoi;

        [BindProperty]
        public string ngayTao { get; set; }

        [BindProperty]
        public int maHang { get; set; }

        [BindProperty]
        public int soLuong { get; set; }

        [BindProperty]
        public double giaBan { get; set; }

        public void OnGet()
        {
        }
        public void OnPost()
        {
            try
            {
                tenHang = _xuLyMatHang.DocTenMatHang(maHang);
                ngayTao = DateTime.Now.ToString("yyyy-MM-dd");
                soLuongTonKhoHienTai = _xuLyMatHang.DocSoLuongTonKho(maHang);
                soLuongTonKhoMoi = soLuongTonKhoHienTai - soLuong;

                kiemTraMaHang = _xuLyMatHang.KiemTraMaHang(maHang);

                if (kiemTraMaHang)
                {
                    if (soLuongTonKhoMoi >= 0)
                    {
                        var hoaDonnBan = new HoaDonBanHang(ngayTao, maHang, tenHang, soLuong, giaBan);
                        _xuLyHoaDonBan.ThemHoaDonBan(hoaDonnBan);
                        _xuLyMatHang.CapNhatTonKho(maHang, soLuongTonKhoMoi);
                        message = "Successful";
                    }
                    else
                    {
                        message = "Số lượng bán lớn hơn số lượng tồn kho!";
                    }
                }
                else
                {
                    message = "Mã hàng không tồn tại!";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }
    }
}

