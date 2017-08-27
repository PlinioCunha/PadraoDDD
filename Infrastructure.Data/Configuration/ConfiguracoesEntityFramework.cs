using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configuration
{

    // FluentAPI

    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            // PRIMARY KEY
            this.HasKey(a => a.IdUsuario);

            this.Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(150);

            // CREATE INDEX COLUMN EMAIL
            this.Property(a => a.Email)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_LoginNameUser", 1)));                

            this.Property(a => a.Foto)
                .HasMaxLength(250);

            this.Property(a => a.PublicKeySocial)
                .HasColumnType("varchar(max)");

            this.Property(a => a.Senha)
                .IsRequired()
                .HasColumnType("varchar(max)");

            this.Property(a => a.SenhaKey)
                .IsRequired()
                .HasColumnType("varchar(max)");

            // DATA CADASTRO
            this.Property(a => a.DataCadastro)
                .HasColumnType("datetime2");

            // MAPAEAMENTO RELACIONAMENTO
            this.HasRequired(a => a.PerfilUsuario)
                .WithMany(a => a.Usuarios)
                .HasForeignKey(a => a.IdPerfilUsuario);

            this.ToTable("Usuario", "dbo");
        }
    }

    public class LogAcessoUsuarioMap : EntityTypeConfiguration<LogAcessoUsuario>
    {
        public LogAcessoUsuarioMap()
        {

        }
    }

    public class ModulosAcessoMap : EntityTypeConfiguration<ModulosAcesso>
    {
        public ModulosAcessoMap()
        {

        }
    }

    public class PerfilUsuarioMap : EntityTypeConfiguration<PerfilUsuario>
    {
        public PerfilUsuarioMap()
        {

        }
    }



}
