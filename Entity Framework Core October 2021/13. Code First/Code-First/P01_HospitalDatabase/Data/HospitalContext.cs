using Microsoft.EntityFrameworkCore;

using P01_HospitalDatabase.Data.Models;
using P01_HospitalDatabase.Common;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext( DbContextOptions options) 
            : base(options)
        {            
        }

        public virtual DbSet<Patient> Patients { get; set; }

        public virtual DbSet<Visitation> Visitations { get; set; }

        public virtual DbSet<Medicament> Medicaments { get; set; }

        public virtual DbSet<Diagnose> Diagnoses { get; set; }

        public virtual DbSet<PatientMedicament> PatientMedicaments { get; set; }

        //02. Hospital Database Modification

        public virtual DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Connection.CONNECTION);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Patient>(p =>
            {
                p.HasKey(p => p.PatientId);

                p.Property(p => p.FirstName)
                 .IsRequired(true)
                 .HasMaxLength(EntityConstants.PATIENT_FIRSTNAME_MAX_LENGTH)
                 .IsUnicode(true);

                p.Property(p => p.LastName)
                 .IsRequired(true)
                 .HasMaxLength(EntityConstants.PATIENT_LASTNAME_MAX_LENGTH)
                 .IsUnicode(true);

                p.Property(p => p.Address)
                 .IsRequired(true)
                 .HasMaxLength(EntityConstants.PATIENT_ADDRESS_MAX_LENGTH)
                 .IsUnicode(true);

                p.Property(p => p.Email)
                 .IsRequired(false)
                 .HasMaxLength(EntityConstants.PATIENT_EMAIL_MAX_LENGTH)
                 .IsUnicode(false);

                p.Property(p => p.HasInsurance)
                 .IsRequired(true);
            });

            builder.Entity<Visitation>(v =>
            {
                v.HasKey(v => v.VisitationId);                

                v.Property(v => v.Date)
                 .IsRequired(true);

                v.Property(v => v.Comments)
                 .IsRequired(false)
                 .HasMaxLength(EntityConstants.VISITATION_COMMENT_MAX_LENGTH)
                 .IsUnicode(true);

                v.HasOne(v => v.Patient)
                 .WithMany(p => p.Visitations)
                 .HasForeignKey(v => v.PatientId);


                // 02. Hospital Database Modification
                v.HasOne(v => v.Doctor)
                 .WithMany(d => d.Visitations)
                 .HasForeignKey(v => v.DoctorId);

            });

            builder.Entity<Diagnose>(d =>
            {
                d.HasKey(d => d.DiagnoseId);

                d.Property(d => d.Name)
                 .IsRequired(true)
                 .HasMaxLength(EntityConstants.DIAGNOSE_NAME_MAX_LENGTH)
                 .IsUnicode(true); 

                d.Property(d => d.Comments)
                 .IsRequired(false)
                 .HasMaxLength(EntityConstants.DIAGNOSE_COMMENT_MAX_LENGTH)
                 .IsUnicode(true);

                d.HasOne(d => d.Patient)
                 .WithMany(d => d.Diagnoses)
                 .HasForeignKey(d => d.PatientId);
            });

            builder.Entity<Medicament>(m =>
            {
                m.HasKey(m => m.MedicamentId);

                m.Property(m => m.Name)
                 .IsRequired(true)
                 .HasMaxLength(EntityConstants.MEDICAMENT_NAME_MAX_LENGTH)
                 .IsUnicode(true);

            });

            builder.Entity<PatientMedicament>(pm =>
            {
                pm.HasKey(pm => new { pm.PatientId, pm.MedicamentId });

                pm.HasOne(pm => pm.Patient)
                 .WithMany(p => p.Prescriptions)
                 .HasForeignKey(pm => pm.PatientId);

                pm.HasOne(pm => pm.Medicament)
                 .WithMany(m => m.Prescriptions)
                 .HasForeignKey(pm => pm.MedicamentId);

            });

            // 02. Hospital Database Modification
            builder.Entity<Doctor>(d =>
            {
                d.HasKey(d => d.DoctorId);

                d.Property(d => d.Name)
                 .IsRequired(true)
                 .HasMaxLength(EntityConstants.DOCTOR_NAME_MAX_LENGTH)
                 .IsUnicode(true);

                d.Property(d => d.Specialty)
                 .IsRequired(true)
                 .HasMaxLength(EntityConstants.DOCTOR_SPECIALITY_MAX_LENGTH)
                 .IsUnicode(true);

            });

        }

    }
}
