using Domain.Entities;
using Infrastructure.Data.Configuration;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Infrastructure.Data.Context
{
    public class ContextoBanco : DbContext
    {
        public ContextoBanco() : base("conexao")
        {
                
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<LogAcessoUsuario> LogAcessoUsuario { get; set; }
        public DbSet<PerfilUsuario> PerfilUsuario { get; set; }
        public DbSet<ModulosAcesso> ModulosAcesso { get; set; }
        public DbSet<LogSystem> LogSystem { get; set; }
        public DbSet<Tarefa> Tarefa { get; set; }
        public DbSet<HistoricoTarefa> HistoricoTarefa { get; set; }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // remove pluralizacao das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            // delete os filhos de 1 : N
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // delete os filhos de N : N
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
          
            // configuracao generic
            modelBuilder.Properties().Where(a => a.Name == "Id" + a.ReflectedType.Name).Configure(a => a.IsKey());
            modelBuilder.Properties<string>().Configure(a => a.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(a => a.HasMaxLength(100));
            modelBuilder.Properties<string>().Where(a => a.Name.Contains("descricao")).Configure(a => a.HasColumnType("varchar(max)"));
            
            //modelBuilder.Properties<DateTime>().Where(a => a.Name.Contains("DataCadastro")).Configure(a => a.);


            // add configuração das classes
            modelBuilder.Configurations.Add(new UsuarioMap());


            base.OnModelCreating(modelBuilder);
        }

    }
}
