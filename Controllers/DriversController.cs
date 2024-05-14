using FormulaAPI.Data;
using FormulaAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FormulaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWOrk;

        public DriversController(IUnitOfWork unitOfWOrk)
        {
            _unitOfWOrk = unitOfWOrk;
        }

        [HttpGet]
        public async Task<IActionResult> GetDriversList()
        {
            return Ok(await _unitOfWOrk.Drivers.AllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriver(int id)
        {
            var driver = await _unitOfWOrk.Drivers.GetByIDAsync(id);
            if (driver == null) return NotFound();

            return Ok(driver);
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddDriver([FromBody] Driver driver)
        {
            await _unitOfWOrk.Drivers.Add(driver);
            await _unitOfWOrk.CompleteAsync();
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateDriver([FromBody] Driver driver)
        {
            var existsDriver = await _unitOfWOrk.Drivers.GetByIDAsync(driver.Id);

            if (existsDriver == null) return NotFound(driver.Id);

            await _unitOfWOrk.Drivers.Update(driver);
            await _unitOfWOrk.CompleteAsync();

            return Ok(driver.Id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var driver = await _unitOfWOrk.Drivers.GetByIDAsync(id);
            await _unitOfWOrk.Drivers.Delete(driver);
            await _unitOfWOrk.CompleteAsync();

            return NoContent();
        }
    }
}
