using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperImplementation.Domain.Entities
{
    public class SalesOrderDetail
    {
        public int SalesOrderID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int OrderQty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPriceDiscount { get; set; }
    }
}
