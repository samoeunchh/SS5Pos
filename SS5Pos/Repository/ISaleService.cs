using System;
using SS5Pos.Models;

namespace SS5Pos.Repository;

public interface ISaleService
{
    Task<List<Sale>> GetSales();
    Task<Sale?> GetSales(Guid Id);
    Task<bool> Save(Sale sale);
    Task<bool> Delete(Guid Id);
    Task<bool> Update(Guid Id, Sale sale);
}

