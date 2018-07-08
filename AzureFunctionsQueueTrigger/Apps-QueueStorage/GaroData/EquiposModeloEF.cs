namespace GaroData
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;

    public class EquiposModeloEF : DbContext
    {
        // Your context has been configured to use a 'EquiposModeloEF' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'GaroData.EquiposModeloEF' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EquiposModeloEF' 
        // connection string in the application configuration file.
        public EquiposModeloEF()
            : base("name=EquiposModeloEF")
        {
        }

        public EquiposModeloEF(string connectionString)
            :base(connectionString)
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Entities.Equipo> Equipos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Entities.Equipo> EntityConfiguration_Equipo =
                modelBuilder.Entity<Entities.Equipo>();

            EntityConfiguration_Equipo.ToTable("EquiposMX", "soccer")
                .HasKey(equipo => equipo.IdEquipo)
                .Property(equipo => equipo.IdEquipo)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            // Configuración de campo fecha.
            EntityConfiguration_Equipo
                .Property(equipo => equipo.Fundacion)
                .HasColumnType("date")
                .HasColumnName("FechaFundacion")
                .IsRequired();
            // Configuración de nombre de equipo.
            EntityConfiguration_Equipo
                .Property(equipo => equipo.Nombre)
                .HasColumnName("Nombre_Apodo")
                .IsUnicode()
                .IsRequired()
                .HasMaxLength(60);
            // Configuración de nombre de presidente.
            EntityConfiguration_Equipo
                .Property(equipo => equipo.Presidente)
                .HasColumnName("Nombre Presidente")
                .IsUnicode()
                .IsOptional()
                .HasMaxLength(50);
            // Configuración de números de títulos.
            EntityConfiguration_Equipo
                .Property(equipo => equipo.Titulos)
                .IsRequired();
        }
    }
}