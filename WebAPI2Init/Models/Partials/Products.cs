using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebApplication1.Models
{
    [MetadataType(typeof(ProductsMD))]
    public partial class Products
    {
        public class ProductsMD
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public Nullable<int> SupplierID { get; set; }
            public Nullable<int> CategoryID { get; set; }
            public string QuantityPerUnit { get; set; }
            public Nullable<decimal> UnitPrice { get; set; }
            public Nullable<short> UnitsInStock { get; set; }
            public Nullable<short> UnitsOnOrder { get; set; }
            public Nullable<short> ReorderLevel { get; set; }
            public bool Discontinued { get; set; }

            [JsonIgnore]
            public virtual ICollection<Order_Details> Order_Details { get; set; }

        }
    }
}