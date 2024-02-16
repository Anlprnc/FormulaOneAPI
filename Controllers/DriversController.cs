using FormulaOne.Core;
using FormulaOne.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Controllers;

[ApiController]
[Route("[controller]")]
public class DriversController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public DriversController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _unitOfWork.Drivers.All());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var driver = await _unitOfWork.Drivers.GetById(id);

        if (driver == null) return NotFound();
        return Ok(driver);
    }

    [HttpPost]
    public async Task<IActionResult> AddDriver([FromBody] Driver driver)
    {
        await _unitOfWork.Drivers.Add(driver);
        await _unitOfWork.CompleteAsync();
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteDriver([FromRoute] int id)
    {
        var driver = await _unitOfWork.Drivers.GetById(id);

        if (driver == null) return NotFound();

        await _unitOfWork.Drivers.Delete(driver);
        await _unitOfWork.CompleteAsync();
        return NoContent();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateDriver([FromBody] Driver driver)
    {
        var existDriver = await _unitOfWork.Drivers.GetById(driver.Id);

        if (existDriver == null) return NotFound();

        await _unitOfWork.Drivers.Update(driver);
        await _unitOfWork.CompleteAsync();
        return NoContent();
    }
}