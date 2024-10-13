using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApi_Minimal1.Models;

public partial class Database : DbContext
{
    public Database()
    {
    }

    public Database(DbContextOptions<Database> options)
        : base(options)
    {
    }

    public virtual DbSet<Film> Films { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:FilmConnStr");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Film>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__film__3213E83F6219BA6A");

            entity.ToTable("film");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Director)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("director");
            entity.Property(e => e.Genre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("genre");
            entity.Property(e => e.InCinema).HasColumnName("inCinema");
            entity.Property(e => e.ReleaseDate).HasColumnName("releaseDate");
            entity.Property(e => e.ScriptLanguage)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("scriptLanguage");
            entity.Property(e => e.Title)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
