using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebApplication1.Models
{
    [MetadataType(typeof(Order_DetailsMD))]
    public partial class Order_Details
    {
        public class Order_DetailsMD
        {
            public int OrderID { get; set; }
            public int ProductID { get; set; }
            public decimal UnitPrice { get; set; }
            public short Quantity { get; set; }
            public float Discount { get; set; }

            [JsonIgnore]
            public virtual Products Products { get; set; }
        }
    }
}