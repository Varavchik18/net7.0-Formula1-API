using FormulaAPI.Data;
using FormulaAPI.Models;
using Microsoft.EntityFrameworkCore;

public class DriverRepository : GenericRepository<Driver>, IDriverRepository
{
  public DriverRepository(ApiDbContext context, ILogger logger) : base(context, logger)
  {
  }

  public override async Task<IEnumerable<Driver>> AllAsync()
  {
    try
    {
      return await _context.Drivers.Where(x => x.Id < 100).ToListAsync();
    }
    catch (System.Exception)
    {

      throw;
    }
  }

  public override async Task<Driver?> GetByIDAsync(int id)
  {
    try
    {
      return await _context.Drivers.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }
    catch (System.Exception)
    {

      throw;
    }
  }


  public async Task<Driver?> GetByDriverNumber(int driverNumber)
  {
    try
    {
      return await _context.Drivers.FirstOrDefaultAsync(x => x.DriverNumber == driverNumber);
    }
    catch (System.Exception)
    {

      throw;
    }
  }
}