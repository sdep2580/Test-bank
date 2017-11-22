using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LtestBank.Models
{
    public class CustomerData
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(10,ErrorMessage ="僅限10碼中英文")]
        [Display(Name = "身分證字號")]
        public string CustomerNo { get; set; }

        [Display(Name ="名子")]
        [StringLength(20,ErrorMessage ="名子過長，請輸入真實名子")]
        public string LastName { get; set; }

        [Display(Name = "姓氏")]
        [StringLength(20, ErrorMessage = "姓氏過長，請輸入真實名子")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "年齡")]
        [Range(1,120,ErrorMessage ="請輸入真實年齡")]
        public Nullable<int> Age { get; set; }

        [Required]
        [Display(Name = "性別 B(男)/G(女)")]
        [MaxLength(1,ErrorMessage ="僅限輸入B(男)、G(女)代表 不分大小寫")]
        [RegularExpression("[b,g,B,G]",ErrorMessage = "僅限輸入B(男)、G(女)代表 不分大小寫")]
        public string Sex { get; set; }


        [Required]
        [Display(Name = "存戶金額")]
        [Range(1,9999999999,ErrorMessage ="不可為0")]
        public decimal AMT { get; set; }


        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<DateTime> SignUpDate { get; set; }
    }
}