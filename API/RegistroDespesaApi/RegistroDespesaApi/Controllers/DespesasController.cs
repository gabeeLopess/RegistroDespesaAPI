using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistroDespesaApi.Base;
using RegistroDespesaApi.Models;

namespace RegistroDespesaApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DespesasController : Controller
	{
		private readonly RegistroDespesaDbContext _registroDespesaDbContext;

		public DespesasController(RegistroDespesaDbContext registroDespesaDbContext)
		{
			_registroDespesaDbContext=registroDespesaDbContext;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllDespesas()
		{
			var despesas = await _registroDespesaDbContext.Despesas.ToListAsync();

			return Ok(despesas);
		}

		[HttpPost]

		public async Task<IActionResult> AddDespesa([FromBody] Despesa despesaRequest)
		{
			despesaRequest.CodDespesa = Guid.NewGuid();
			await _registroDespesaDbContext.Despesas.AddAsync(despesaRequest);
			await _registroDespesaDbContext.SaveChangesAsync();

			return Ok(despesaRequest);
		}

		[HttpGet]
		[Route("{codDespesa:Guid}")]
		public async Task<IActionResult> GetDespesa([FromRoute] Guid codDespesa)
		{
			var despesa =
				await _registroDespesaDbContext.Despesas.FirstOrDefaultAsync(x => x.CodDespesa == codDespesa);

			if (despesa == null)
			{
				return NotFound();
			}

			return Ok(despesa);
		}


		[HttpPut]
		[Route("{codDespesa:Guid}")]
		public async Task<IActionResult> UpdateDespesa([FromRoute] Guid codDespesa, Despesa updateDespesaRequest)
		{
			var despesa = await _registroDespesaDbContext.Despesas.FindAsync(codDespesa);


			if (despesa == null)
			{
				return NotFound();

			}

			despesa.NomeDespesa = updateDespesaRequest.NomeDespesa;
			despesa.DescricaoDespesa = updateDespesaRequest.DescricaoDespesa;
			despesa.Data = updateDespesaRequest.Data;
			despesa.Valor = updateDespesaRequest.Valor;

			await _registroDespesaDbContext.SaveChangesAsync();

			return Ok(despesa);
		}

		[HttpDelete]
		[Route("{codDespesa:Guid}")]
		public async Task<IActionResult> DeleteDespesa([FromRoute] Guid codDespesa)
		{
			var despesa = await _registroDespesaDbContext.Despesas.FindAsync(codDespesa);

			if(despesa == null)
			{
				return NotFound();	
			}


			_registroDespesaDbContext.Despesas.Remove(despesa);
			await _registroDespesaDbContext.SaveChangesAsync();

			return Ok(despesa);	
		}

    }

}