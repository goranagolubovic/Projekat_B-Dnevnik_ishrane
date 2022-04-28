using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Projekat_B_Dnevnik_ishrane.models
{
  public partial class dbModel : DbContext
  {
    public dbModel()
        : base("name=dbModel")
    {
    }

    public virtual DbSet<kandidat> kandidats { get; set; }
    public virtual DbSet<korisnik> korisniks { get; set; }
    public virtual DbSet<mjerenje> mjerenjes { get; set; }
    public virtual DbSet<namirnica> namirnicas { get; set; }
    public virtual DbSet<obrok> obroks { get; set; }
    public virtual DbSet<plan_ishrane> plan_ishrane { get; set; }
    public virtual DbSet<plan_vjezbanja> plan_vjezbanja { get; set; }
    public virtual DbSet<trener> treners { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<kandidat>()
          .HasMany(e => e.obroks)
          .WithRequired(e => e.kandidat)
          .HasForeignKey(e => e.KANDIDAT_KORISNIK_idKORISNIK)
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<kandidat>()
          .HasMany(e => e.plan_ishrane)
          .WithRequired(e => e.kandidat)
          .HasForeignKey(e => e.KANDIDAT_KORISNIK_idKORISNIK)
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<kandidat>()
          .HasMany(e => e.plan_vjezbanja)
          .WithRequired(e => e.kandidat)
          .HasForeignKey(e => e.KANDIDAT_KORISNIK_idKORISNIK)
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<kandidat>()
          .HasMany(e => e.mjerenjes)
          .WithRequired(e => e.kandidat)
          .HasForeignKey(e => e.KANDIDAT_KORISNIK_idKORISNIK)
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<korisnik>()
          .Property(e => e.Ime)
          .IsUnicode(false);

      modelBuilder.Entity<korisnik>()
          .Property(e => e.Prezime)
          .IsUnicode(false);

      modelBuilder.Entity<korisnik>()
          .Property(e => e.KorisnickoIme)
          .IsUnicode(false);

      modelBuilder.Entity<korisnik>()
          .Property(e => e.Lozinka)
          .IsUnicode(false);

      modelBuilder.Entity<korisnik>()
          .HasOptional(e => e.kandidat)
          .WithRequired(e => e.korisnik)
          .WillCascadeOnDelete();

      modelBuilder.Entity<korisnik>()
          .HasOptional(e => e.trener)
          .WithRequired(e => e.korisnik);

      modelBuilder.Entity<namirnica>()
          .Property(e => e.Naziv)
          .IsUnicode(false);

      modelBuilder.Entity<namirnica>()
          .HasMany(e => e.obroks)
          .WithRequired(e => e.namirnica)
          .HasForeignKey(e => e.NAMIRNICA_idNAMIRNICA)
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<obrok>()
          .Property(e => e.TipObroka)
          .IsUnicode(false);

      modelBuilder.Entity<plan_ishrane>()
          .Property(e => e.Opis)
          .IsUnicode(false);

      modelBuilder.Entity<plan_ishrane>()
          .Property(e => e.Dan)
          .IsUnicode(false);

      modelBuilder.Entity<plan_vjezbanja>()
          .Property(e => e.Opis)
          .IsUnicode(false);

      modelBuilder.Entity<plan_vjezbanja>()
          .Property(e => e.Dan)
          .IsUnicode(false);

      modelBuilder.Entity<trener>()
          .HasMany(e => e.kandidats)
          .WithRequired(e => e.trener)
          .HasForeignKey(e => e.TRENER_KORISNIK_idKORISNIK)
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<trener>()
          .HasMany(e => e.mjerenjes)
          .WithRequired(e => e.trener)
          .HasForeignKey(e => e.TRENER_KORISNIK_idKORISNIK)
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<trener>()
          .HasMany(e => e.plan_ishrane)
          .WithRequired(e => e.trener)
          .HasForeignKey(e => e.TRENER_KORISNIK_idKORISNIK)
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<trener>()
          .HasMany(e => e.plan_vjezbanja)
          .WithRequired(e => e.trener)
          .HasForeignKey(e => e.TRENER_KORISNIK_idKORISNIK)
          .WillCascadeOnDelete(false);
    }
  }
}
