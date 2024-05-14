using FormulaAPI.Models;

public interface IDriverRepository : IGenericRepository<Driver>
{
  Task<Driver?> GetByDriverNumber(int driverNumber);
}