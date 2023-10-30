using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    internal class ProductDTO
    {
        public int ProductId { get; set; }

        public int? CategoryId { get; set; }

        public string? ProductName { get; set; }

        public string? Description { get; set; }

        public decimal? Price { get; set; }

        public string? Size { get; set; }

        public string? Color { get; set; }

        public int? Quantity { get; set; }

        public string? ImageUrl { get; set; }
    }
}
