using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Models
{
    [MetadataType(typeof(FCustomerMetadata))]
    public partial class FCustomerData
    {
        public class FCustomerMetadata
        {
           public int Id { get; set; }
           

           public string CustomerNo { get; set; }


           public string LastName { get; set; }


           public string FirstName { get; set; }


           public string Curcd { get; set; }


           public Nullable<decimal> Rate { get; set; }


           public Nullable<decimal> Amt { get; set; }
           

            public string Company_yn { get; set; }

            public string Freeze_yn { get; set; }

            public string Obu { get; set; }
           
           public Nullable<System.DateTime> ModifyDate { get; set; }
        }
    }
}