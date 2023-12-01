using ListaTarefas.Entities;

namespace ListaTarefas.Persistence.Repositories
{
    public interface ITarefaRepository
    {
        List<Tarefa> GetAll();
        Tarefa GetById(int id);
        void Add (Tarefa tarefa);
        void Update(Tarefa tarefa);
        bool Delete (int id);
    }
}