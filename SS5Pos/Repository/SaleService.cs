using System;
using Microsoft.EntityFrameworkCore;
using SS5Pos.Data;
using SS5Pos.Models;

namespace SS5Pos.Repository
{
	public class SaleService:ISaleService,IDisposable
	{
        private readonly AppDbContext _context;
		public SaleService(AppDbContext context)
		{
            _context = context;
		}

        public async Task<bool> Delete(Guid Id)
        {
            try
            {
                var sale = await _context.Sale.FindAsync(Id);
                if (sale is null) return false;
                _context.Sale.Remove(sale);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<List<Sale>> GetSales()
            => await _context.Sale.ToListAsync();

        public async Task<Sale?> GetSales(Guid Id)
            => await _context.Sale.FindAsync(Id);

        public async Task<bool> Save(Sale sale)
        {
            try
            {
                sale.InvoiceNumber = GenderateInvoice();
                sale.SaleId = Guid.NewGuid();
                _context.Sale.Add(sale);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private string GenderateInvoice()
            => DateTime.Now.ToString("yyMMddHHmmsstt");
        public async Task<bool> Update(Guid Id, Sale sale)
        {
            try
            {
                var s = await _context.Sale.FindAsync(Id);
                if (s is null) return false;
                _context.Sale.Attach(s);
                s.CustomerId = sale.CustomerId;
                s.Discount = sale.Discount;
                s.GrandTotal = sale.GrandTotal;
                s.IssueDate = sale.IssueDate;
                s.Total = sale.Total;
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

