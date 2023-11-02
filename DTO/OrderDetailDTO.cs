using System;
namespace DTO
{
	public class OrderDetailDTO
	{
        public int OrderDetailId { get; set; }

        public int? OrderId { get; set; }

        public int? ProductId { get; set; }

        public int? Quantity { get; set; }

        public string? Description { get; set; }
    }
}

