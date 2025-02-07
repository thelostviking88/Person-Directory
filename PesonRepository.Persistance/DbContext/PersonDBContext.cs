using Microsoft.EntityFrameworkCore;
using PersonDirectory.Domain.Enums;
using System;

namespace PersonDirectory.Domain.Models;

public partial class PersonDbContext : DbContext
{
    public PersonDbContext() { }

    public PersonDbContext(DbContextOptions<PersonDbContext> options)
        : base(options) { }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<PersonConnection> PersonConnections { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("City");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Person");

            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PrivateNumber).HasMaxLength(11);

            entity.HasOne(d => d.City).WithMany(p => p.People)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            //entity.HasMany(p => p.Connections)
            //    .WithOne(c => c.MainPerson)
            //    .HasForeignKey(c => c.PersonId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //entity.HasMany(p => p.ConnectionsBy)
            //    .WithOne(c => c.ConnectedPerson)
            //    .HasForeignKey(c => c.ConnectedPersonId)
            //    .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<PersonConnection>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("PersonConnection");

            entity.HasOne(d => d.MainPerson).WithMany(p => p.Connections)
               .HasForeignKey(d => d.PersonId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_PersonConnection_Person");

            entity.HasOne(d => d.ConnectedPerson).WithMany(p => p.ConnectionsBy)
                            .HasForeignKey(d => d.ConnectedPersonId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("FK_PersonConnection_PersonConnection");

           

            //entity.Property(e => e.ConnectionType)
            //    .HasConversion(
            //        v => v.ToString(),
            //        v => (ConnectionTypes)Enum.Parse(typeof(ConnectionTypes), v));

        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Phone");

            entity.Property(e => e.Number).HasMaxLength(50);

            entity.HasOne(d => d.Person)
                .WithMany(p => p.Phones)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
