using ListaTarefas.Enums;

namespace ListaTarefas.Models
{
    public record AdicionarTarefaModel (string Titulo, string Descricao, StatusTarefaEnum Status)
    {
        
    }
}