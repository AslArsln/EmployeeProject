using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EmployeeProject.Entity
{
    public partial class ModelEmployeeEntity : DbContext
    {
        internal object employee;

        public ModelEmployeeEntity()
            : base("name=ModelEmployeeEntity")
        {
        }

        public virtual DbSet<Unit> Birimlers { get; set; }
        public virtual DbSet<Employee> Personellers { get; set; }
        public virtual DbSet<ViewEmployeeUnit> ViewPersonelBirims { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unit>()
                .Property(e => e.BirimAdi)
                .IsUnicode(false);

            modelBuilder.Entity<Unit>()
                .Property(e => e.Aciklama)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.AdiSoyadi)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Adres)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<ViewEmployeeUnit>()
                .Property(e => e.AdiSoyadi)
                .IsUnicode(false);

            modelBuilder.Entity<ViewEmployeeUnit>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<ViewEmployeeUnit>()
                .Property(e => e.Adres)
                .IsUnicode(false);

            modelBuilder.Entity<ViewEmployeeUnit>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<ViewEmployeeUnit>()
                .Property(e => e.BirimAdi)
                .IsUnicode(false);
        }
    }
}
