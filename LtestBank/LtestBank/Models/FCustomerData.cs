using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LtestBank.Models
{
    public class FCustomerData
    {
        public int Id { get; set; }


        [Required]
        [Display(Name = "身分證字號")]
        [StringLength(10, ErrorMessage = "僅限10碼中英文")]
        public string CustomerNo { get; set; }

        [Display(Name = "名子")]
        [StringLength(10, ErrorMessage = "僅限10碼中英文")]
        public string LastName { get; set; }

        [Display(Name = "姓氏")]
        [StringLength(10, ErrorMessage = "僅限10碼中英文")]
        public string FirstName { get; set; }

        [Display(Name = "幣別")]
        [StringLength(3, ErrorMessage = "僅限3碼英文")]
        public string Curcd { get; set; }

        [Display(Name = "匯率")]
        [Required]
        [Range(1, 9999999999, ErrorMessage = "不可為0")]
        public Nullable<decimal> Rate { get; set; }

        [Display(Name = "金額")]
        [Range(1, 9999999999, ErrorMessage = "不可為0")]
        public Nullable<decimal> Amt { get; set; }

        [Display(Name = "公司戶")]
        [RegularExpression("[y,n,Y,N]", ErrorMessage = "僅限輸入Y、N代表 不分大小寫")]
        [StringLength(1, ErrorMessage = "僅限1碼英文")]
        public string Company_yn { get; set; }

        [Display(Name = "凍結記號")]
        [RegularExpression("[y,n,Y,N]", ErrorMessage = "僅限輸入Y、N代表 不分大小寫")]
        [StringLength(1, ErrorMessage = "僅限1碼英文")]
        public string Freeze_yn { get; set; }

        [Display(Name = "OBU記號")]
        [StringLength(1, ErrorMessage = "僅限1碼")]
        [Range(0, 3, ErrorMessage = " 0 ~ 3")]
        public string Obu { get; set; }

        [Display(Name = "修改日期")]
        public Nullable<System.DateTime> ModifyDate { get; set; }
    }
}