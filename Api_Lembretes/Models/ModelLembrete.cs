namespace Api_Lembretes.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelLembrete : DbContext
    {
        public ModelLembrete()
            : base("name=ModelLembrete")
        {
        }

        public virtual DbSet<tb_Lembrete> tb_Lembrete { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_Lembrete>()
                .Property(e => e.Autor)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Lembrete>()
                .Property(e => e.Conteudo)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Lembrete>()
                .Property(e => e.Prioridade)
                .IsUnicode(false);
        }
    }
}
