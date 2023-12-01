namespace ListaTarefas.Entities;
using System;
using System.Collections.Generic;
using ListaTarefas.Enums;

public class Tarefa
{
    public Tarefa(string titulo, string descricao, StatusTarefaEnum status)
    {
        Titulo = titulo;
        Descricao = descricao;
        Status = status;
    }
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Titulo { get; set; }
    public string ?Descricao { get; set; }
    public StatusTarefaEnum Status { get; set; }
    public void Update(string titulo, string descricao ){
            Titulo = titulo;
            Descricao = descricao;
        }

}
