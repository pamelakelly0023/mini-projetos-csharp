namespace ListaTarefas.Controllers
{
    using ListaTarefas.Entities;
    using ListaTarefas.Models;
    using ListaTarefas.Persistence.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
	using Microsoft.AspNetCore.Authorization;

	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class TarefaController : ControllerBase
	{
		private readonly ITarefaRepository _repository;
		public TarefaController(ITarefaRepository repository)
		{
			_repository = repository;
		}

		[HttpPost]
		public IActionResult Post(AdicionarTarefaModel model)
		{
			var tarefa = new Tarefa (
				model.Titulo,
				model.Descricao,
				model.Status
			);
			
			_repository.Add(tarefa);

			return CreatedAtAction("GetById", new { id = tarefa.Id }, tarefa);
		}
		[HttpGet]
		public IActionResult GetAll()
		{
			var tarefa = _repository.GetAll();
			return Ok(tarefa);
		}
		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var tarefa = _repository.GetById(id);

			if(tarefa == null)
			{
				return NotFound();
			}
			return Ok(tarefa);
		}
		[HttpPut("{id}")]
		public IActionResult Put (int id, AtualizarTarefaModel model)
		{
			var tarefa = _repository.GetById(id);
            if(tarefa == null)
            {
                return NotFound();
            }

            tarefa.Update(model.Titulo, model.Descricao);
            _repository.Update(tarefa);
            
            return NoContent();
		}
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var tarefa = _repository.GetById(id);
            if(tarefa == null)
            {
                return NotFound();
            } 
			_repository.Delete(tarefa.Id);
            
            return NoContent();
		}
	}
	
}

