using App.Core;
using App.Core.Models.UnitModule.DTOs;
using App.Core.Repositories;
using App.EF.Repositories;
using AutoMapper;
using InvetorySystem.Core.Models.UnitModule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UnitsController(IUnitOfWork UnitOfWork, IMapper mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UnitAddRequest unit)
        {
            var unitModel = _mapper.Map<Unit>(unit);
            var result = await _unitOfWork.Units.AddAsync(unitModel);
            await _unitOfWork.CommitAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _unitOfWork.Units.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.Units.GetAllAsync());
        }
        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            return Ok(await _unitOfWork.Units.FindAsync(x => x.Name == name));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UnitUpdateRequest unit)
        {
            var unitModel = _mapper.Map<Unit>(unit);
            await _unitOfWork.Units.UpdateAsync(unitModel);
            await _unitOfWork.CommitAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.Units.RemoveAsync(id);
            await _unitOfWork.CommitAsync();

            return Ok();
        }

        [HttpPost("Add-Range")]
        public async Task<IActionResult> AddRange([FromBody] List<UnitAddRequest> units)
        {
            var unitModels = _mapper.Map<List<Unit>>(units);
            var result = await _unitOfWork.Units.AddRangeAsync(unitModels);
            await _unitOfWork.CommitAsync();

            return Ok(result);
        }

        [HttpGet("Count")]
        public async Task<IActionResult> GetCount()
        {
            return Ok(await _unitOfWork.Units.Count());
        }
    }
}
