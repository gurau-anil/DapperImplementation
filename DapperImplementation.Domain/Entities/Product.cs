using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperImplementation.Domain.Entities
{
    public class Product
	{
		public int ProductID { get; set; }
		public string ProductNumber { get; set; }
		public string Color { get; set; }
		public decimal StandardCost { get; set; }
		public decimal ListPrice { get; set; }
		public string Size { get; set; }
		public decimal Weight { get; set; }
		public int ProductCategoryID { get; set; }
		public int ProductModelID { get; set; }

        public ProductCategory ProductCategory { get; set; }
        public ProductModel ProductModel { get; set; }
	}
}
