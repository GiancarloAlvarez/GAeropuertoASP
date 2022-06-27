using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GAeropuerto.Models
{
    public partial class BDGAeropuertoContext : DbContext
    {
        public BDGAeropuertoContext()
        {
        }

        public BDGAeropuertoContext(DbContextOptions<BDGAeropuertoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Avione> Aviones { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Estadium> Estadia { get; set; } = null!;
        public virtual DbSet<Hangar> Hangars { get; set; } = null!;
        public virtual DbSet<Modelo> Modelos { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Piloto> Pilotos { get; set; } = null!;
        public virtual DbSet<Propietario> Propietarios { get; set; } = null!;
        public virtual DbSet<TipoAvion> TipoAvions { get; set; } = null!;
        public virtual DbSet<Vuelo> Vuelos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=BDGAeropuerto.mssql.somee.com;Database=BDGAeropuerto;User ID=ggPrueba_SQLLogin_2;Password = v7va7h18v9");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avione>(entity =>
            {
                entity.HasKey(e => e.IdAvion)
                    .HasName("PK__Aviones__66D8A4F3C6552DC4");

                entity.Property(e => e.IdAvion).HasColumnName("id_avion");

                entity.Property(e => e.CapacidadPeso).HasColumnName("capacidad_peso");

                entity.Property(e => e.IdModelo).HasColumnName("id_modelo");

                entity.Property(e => e.IdPropietario).HasColumnName("id_propietario");

                entity.Property(e => e.IdTipoAvion).HasColumnName("id_tipoAvion");

                entity.Property(e => e.SiglasAvion)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("siglas_avion");

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.Aviones)
                    .HasForeignKey(d => d.IdModelo)
                    .HasConstraintName("FK__Aviones__id_mode__31EC6D26");

                entity.HasOne(d => d.IdPropietarioNavigation)
                    .WithMany(p => p.Aviones)
                    .HasForeignKey(d => d.IdPropietario)
                    .HasConstraintName("FK__Aviones__id_prop__32E0915F");

                entity.HasOne(d => d.IdTipoAvionNavigation)
                    .WithMany(p => p.Aviones)
                    .HasForeignKey(d => d.IdTipoAvion)
                    .HasConstraintName("FK__Aviones__id_tipo__30F848ED");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PK__Empleado__88B5139469E41DE5");

                entity.ToTable("Empleado");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.SueldoEmpleado).HasColumnName("sueldo_empleado");

                entity.Property(e => e.TurnoEmpleado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("turno_empleado");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("FK__Empleado__id_per__37A5467C");
            });

            modelBuilder.Entity<Estadium>(entity =>
            {
                entity.HasKey(e => e.IdEstadia)
                    .HasName("PK__Estadia__3F2F78D762CAA579");

                entity.Property(e => e.IdEstadia).HasColumnName("id_estadia");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_fin");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_inicio");

                entity.Property(e => e.IdAvion).HasColumnName("id_avion");

                entity.Property(e => e.IdHangar).HasColumnName("id_hangar");

                entity.HasOne(d => d.IdAvionNavigation)
                    .WithMany(p => p.Estadia)
                    .HasForeignKey(d => d.IdAvion)
                    .HasConstraintName("FK__Estadia__id_avio__3B75D760");

                entity.HasOne(d => d.IdHangarNavigation)
                    .WithMany(p => p.Estadia)
                    .HasForeignKey(d => d.IdHangar)
                    .HasConstraintName("FK__Estadia__id_hang__3A81B327");
            });

            modelBuilder.Entity<Hangar>(entity =>
            {
                entity.HasKey(e => e.IdHangar)
                    .HasName("PK__Hangar__243A14E2C20F5D3A");

                entity.ToTable("Hangar");

                entity.Property(e => e.IdHangar).HasColumnName("id_hangar");

                entity.Property(e => e.Capacidad).HasColumnName("capacidad");

                entity.Property(e => e.CodigoHangar)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("codigo_hangar");

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ubicacion");
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.HasKey(e => e.IdModelo)
                    .HasName("PK__Modelo__B3BFCFF1738474C3");

                entity.ToTable("Modelo");

                entity.Property(e => e.IdModelo).HasColumnName("id_modelo");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.IdPiloto).HasColumnName("id_piloto");

                entity.Property(e => e.Motores).HasColumnName("motores");

                entity.Property(e => e.Peso).HasColumnName("peso");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.HasOne(d => d.IdPilotoNavigation)
                    .WithMany(p => p.Modelos)
                    .HasForeignKey(d => d.IdPiloto)
                    .HasConstraintName("FK__Modelo__id_pilot__2E1BDC42");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK__Persona__228148B0099BFCB3");

                entity.ToTable("Persona");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cedula");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Piloto>(entity =>
            {
                entity.HasKey(e => e.IdPiloto)
                    .HasName("PK__Piloto__93ED5235924CA7CD");

                entity.ToTable("Piloto");

                entity.Property(e => e.IdPiloto).HasColumnName("id_piloto");

                entity.Property(e => e.FechaRev)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_rev");

                entity.Property(e => e.HorasVuelo).HasColumnName("horas_vuelo");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.Licencia)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("licencia");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Pilotos)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("FK__Piloto__id_perso__286302EC");
            });

            modelBuilder.Entity<Propietario>(entity =>
            {
                entity.HasKey(e => e.IdPropietario)
                    .HasName("PK__Propieta__D2E569377BFD1C88");

                entity.ToTable("Propietario");

                entity.Property(e => e.IdPropietario).HasColumnName("id_propietario");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.Rif)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("rif");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Propietarios)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("FK__Propietar__id_pe__2B3F6F97");
            });

            modelBuilder.Entity<TipoAvion>(entity =>
            {
                entity.HasKey(e => e.IdTipoAvion)
                    .HasName("PK__Tipo_Avi__446DB5A6C45AF673");

                entity.ToTable("Tipo_Avion");

                entity.Property(e => e.IdTipoAvion).HasColumnName("id_tipoAvion");

                entity.Property(e => e.TipoAvion1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("tipo_avion");
            });

            modelBuilder.Entity<Vuelo>(entity =>
            {
                entity.HasKey(e => e.IdVuelo)
                    .HasName("PK__Vuelos__CA179BA243CDEF1C");

                entity.Property(e => e.IdVuelo).HasColumnName("id_vuelo");

                entity.Property(e => e.FechaVuelo)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_vuelo");

                entity.Property(e => e.IdAvion).HasColumnName("id_avion");

                entity.Property(e => e.IdPiloto).HasColumnName("id_piloto");

                entity.Property(e => e.NumeroVuelo).HasColumnName("numero_vuelo");

                entity.HasOne(d => d.IdAvionNavigation)
                    .WithMany(p => p.Vuelos)
                    .HasForeignKey(d => d.IdAvion)
                    .HasConstraintName("FK__Vuelos__id_avion__3E52440B");

                entity.HasOne(d => d.IdPilotoNavigation)
                    .WithMany(p => p.Vuelos)
                    .HasForeignKey(d => d.IdPiloto)
                    .HasConstraintName("FK__Vuelos__id_pilot__3F466844");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
