//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fitnes.Entites
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Fitnes : DbContext
    {
        public Fitnes()
            : base("name=Fitnes")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }
        public virtual DbSet<WorkDay> WorkDays { get; set; }
        public virtual DbSet<Заявка_на_инд_занятия> Заявка_на_инд_занятия { get; set; }
        public virtual DbSet<Заявка_на_обучение> Заявка_на_обучение { get; set; }
    }
}
