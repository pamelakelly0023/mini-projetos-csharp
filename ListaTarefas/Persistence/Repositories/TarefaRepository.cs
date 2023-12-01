
using ListaTarefas.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ListaTarefas.Persistence.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly TarefaContext _context;
        public TarefaRepository(TarefaContext context)
        {
            _context = context;
        }
        public void Add(Tarefa tarefa)
        {
           _context.Tarefas.Add(tarefa);
           _context.SaveChanges();
        }

        public List<Tarefa> GetAll()
        {
            return _context.Tarefas.ToList();
        }

        public Tarefa GetById(int id)
        {
            return _context.Tarefas
            .SingleOrDefault(x => x.Id == id);
        }
        public bool Delete (int id)
        {
            var result = _context.Tarefas.SingleOrDefault(x => x.Id.Equals(id));
            if (result == null)
            {
                return false;
            }

            _context.Remove(result);
            _context.SaveChanges();
            return true;
        }

        public void Update(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
            _context.SaveChanges();
        }

    }
}