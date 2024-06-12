using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DOAN_LTW_HVC.Models
{
    public class SANPHAM
    {
        [Key]
        public int MASP { get; set; }
        [Required(ErrorMessage ="Tên sản phẩm không được để trống!")]
        [RegularExpression(@"^[0-9aAàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆfFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTuUùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ ]*$", ErrorMessage = "Bạn không được nhập ký tự đặc biệt")]
        public string TENSP { get; set; }
        [Required(ErrorMessage = "Layout không được để trống!")]
        public string LAYOUT { get; set; }
        public string DUONGDAN { get; set; }
        [Required(ErrorMessage = "Giá không được để trống!")]
        [DisplayFormat(DataFormatString = "{0:C0} VND")]
        [Range(0, 20000000, ErrorMessage ="Giá của sản phẩm phải nhỏ hơn 20tr")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Bạn chỉ được nhập số")]
        public int GIA { get; set; }
        [Required(ErrorMessage = "Mô tả không được để trống!")]
        public string MOTA { get; set; }
        [Required(ErrorMessage = "Thương hiệu không được để trống!")]
        public Nullable<int> MATH { get; set; }
        [Required(ErrorMessage = "Loại sản phẩm không được để trống!")]
        public Nullable<int> MALOAI { get; set; }

        public virtual THUONGHIEU THUONGHIEU { get; set; }
        public virtual LOAISANPHAM LOAISANPHAM { get; set; }
    }
}