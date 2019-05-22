using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Finance.Core.Contract;
using Finance.Domain.Models;
using Finance.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Controllers
{
    [Produces("application/json")]
    [Route("api/Despesas")]
    public class OperationsController : Controller
    {
        private readonly IService<Despesa, DTODeDespesa> _service;
        private readonly IRepositoryQuery<Despesa, DTODeDespesa> _query;

        public OperationsController(IService<Despesa, DTODeDespesa> service, IRepositoryQuery<Despesa, DTODeDespesa> query)
        {
            _service = service;
            _query = query;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _query.GetAll().ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _query.Get(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DTODeDespesa dto, CancellationToken ct = default(CancellationToken))
        {
            dto = await _service.Add(dto, ct);

            return Ok(dto);
        }

        [HttpPut, HttpOptions]
        public async Task<IActionResult> Put([FromBody] DTODeDespesa dto, CancellationToken ct = default(CancellationToken))
        {
            var result = _query.Get(dto.Id);

            if (result == null)
            {
                return NotFound();
            }

            dto = await _service.Update(dto, ct);

            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct = default(CancellationToken))
        {
            var result = _query.Get(id);

            if (result == null)
            {
                return NotFound();
            }

            await _service.Delete(id, ct);

            return NoContent();
        }
    }
}
