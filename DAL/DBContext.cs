using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Nettbank.DAL
{
    public class Personer
    {
        [Key]
        public string Persnr { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public string Postnr { get; set; }
        public string Telefonnr { get; set; }
        public byte[] Passord { get; set; }
        public virtual Poststeder Poststeder { get; set; }
        public virtual Kontoer Kontoer { get; set; }
    }

    public class Poststeder
    {
        [Key]
        public string Postnr { get; set; }
        public string Poststed { get; set; }
        public virtual List<Personer> Personer { get; set; }
    }

    public class Kontoer
    {
        [Key]
        public string Kontonr { get; set; }
        public string Persnr { get; set; }
        public string DatoOppretting { get; set; }
        public string Saldo { get; set; }
        public virtual List<Personer> Personer { get; set; }
        public virtual List<Transaskjoner> Transaksjoner { get; set; }
    }

    public class Transaskjoner
    {
        public int ID { get; set; }
        public string FraKonto { get; set; }
        public string TilKonto { get; set; }
        public string Beløp { get; set; }
        public string Kid { get; set; }
        public string Dato { get; set; }
        public bool Bekreftet { get; set; }
        public virtual List<Kontoer> Kontoer { get; set; }
    }
    public class PersonContext : DbContext
    {
        public PersonContext()
            : base("name=Personer")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Personer> Kunder { get; set; }
        public DbSet<Poststeder> Poststeder { get; set; }
        public DbSet<Kontoer> Kontoer { get; set; }
        public DbSet<Transaskjoner> Transaksjoner { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}