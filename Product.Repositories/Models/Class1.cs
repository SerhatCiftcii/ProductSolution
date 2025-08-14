using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repositories.Models
{

    public class Product
    {

        public int Id { get; set; }


        public string ProductName { get; set; } = string.Empty;


        public string ProductDescription { get; set; } = string.Empty;


        public decimal ProductPrice { get; set; }

        public int ProductStock { get; set; }

    }
}
