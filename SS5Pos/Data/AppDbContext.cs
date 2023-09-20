using System;
using Microsoft.EntityFrameworkCore;
using SS5Pos.Models;

namespace SS5Pos.Data
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			:base(options)
		{
		}
		public DbSet<Category> Category { get; set; }
		public DbSet<Product> Proeduct { get; set; }
		public DbSet<Customer> Customer { get; set; }
		public DbSet<Sale> Sale { get; set; }
		public DbSet<SaleDetail> SaleDetail { get; set; }
	}
}

