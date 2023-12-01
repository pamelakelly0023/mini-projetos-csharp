using System.Collections.Generic;
using ListaTarefas.Entities;
using Microsoft.EntityFrameworkCore;

namespace ListaTarefas.Persistence
{
    public class TarefaContext : DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> options) : base(options)
        {}
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

             modelBuilder.Entity<Tarefa>(e => {
               e.ToTable("tb_tarefas");
               e.HasKey(x => x.Id); 
               e.Property(x => x.Titulo).IsRequired();
               e.Property(x => x.Descricao).IsRequired();
               e.Property(x => x.Status).IsRequired();
            });  
        }

    }
}