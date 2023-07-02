using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Prueba4Crud.Models;

public partial class Bdprueba4Context : DbContext
{
    public Bdprueba4Context()
    {
    }

    public Bdprueba4Context(DbContextOptions<Bdprueba4Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Tbbiblioteca> Tbbibliotecas { get; set; }

    public virtual DbSet<Tbcita> Tbcitas { get; set; }

    public virtual DbSet<Tbdoctor> Tbdoctors { get; set; }

    public virtual DbSet<Tbpaciente> Tbpacientes { get; set; }

    public virtual DbSet<Tbusuario> Tbusuarios { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder);
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("server=masbien; database=BDPrueba4; integrated security=true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tbbiblioteca>(entity =>
        {
            entity.HasKey(e => e.IdLibro).HasName("PK__TBBiblio__3E0B49ADD8B8516D");

            entity.ToTable("TBBiblioteca");

            entity.Property(e => e.IdLibro).ValueGeneratedNever();
            entity.Property(e => e.Autor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("autor");
            entity.Property(e => e.Año).HasColumnName("año");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("especialidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Tbcita>(entity =>
        {
            entity.HasKey(e => e.IdCita).HasName("PK__TBCitas__394B02024F12B6B8");

            entity.ToTable("TBCitas");

            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.Hora).HasColumnName("hora");
            entity.Property(e => e.IdDoctor).HasColumnName("idDoctor");
            entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");
            entity.Property(e => e.ModoCita)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modoCita");
            entity.Property(e => e.Previsión)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("previsión");

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.Tbcita)
                .HasForeignKey(d => d.IdDoctor)
                .HasConstraintName("FK__TBCitas__idDocto__3C69FB99");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Tbcita)
                .HasForeignKey(d => d.IdPaciente)
                .HasConstraintName("FK__TBCitas__idPacie__3D5E1FD2");
        });

        modelBuilder.Entity<Tbdoctor>(entity =>
        {
            entity.HasKey(e => e.IdDoctor).HasName("PK__TBDoctor__418956C3E7A6C6B3");

            entity.ToTable("TBDoctor");

            entity.Property(e => e.IdDoctor).HasColumnName("idDoctor");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Convenio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("convenio");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("especialidad");
            entity.Property(e => e.Fono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("fono");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.TipoCita)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_Cita");
        });

        modelBuilder.Entity<Tbpaciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__TBPacien__F48A08F2ED4E7B70");

            entity.ToTable("TBPaciente");

            entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Dirección)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("dirección");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Fono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("fono");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Previsión)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("previsión");
        });

        modelBuilder.Entity<Tbusuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__TBUsuari__5B65BF97E8303CDA");

            entity.ToTable("TBUsuario");

            entity.Property(e => e.IdUsuario).ValueGeneratedNever();
            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Fono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("fono");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Perfil)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("perfil");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
