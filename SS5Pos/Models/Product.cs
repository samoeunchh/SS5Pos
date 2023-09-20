using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SS5Pos.Models;

public class Product
{
	[Key]
	public Guid ProductId { get; set; }
	[Required]
	[MaxLength(50)]
	[Display(Name ="Product Name")]
	public string? ProductName { get; set; }
    [Required]
    [MaxLength(20)]
    public string? Barcode { get; set; }
	public double Price { get; set; }
	public int Qty { get; set; }
	public int? ReOrderQty { get; set; }
	[ForeignKey("Category")]
	public Guid CategoryId { get; set; }

	public Category? Category { get; set; }
}

