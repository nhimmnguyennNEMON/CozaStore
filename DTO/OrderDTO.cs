using System;
namespace DTO
{
	public class OrderDTO
	{
        public int OrderId { get; set; }

        public int? UserId { get; set; }

        public string? OrderDate { get; set; }

        public int? Status { get; set; }
    }
}

