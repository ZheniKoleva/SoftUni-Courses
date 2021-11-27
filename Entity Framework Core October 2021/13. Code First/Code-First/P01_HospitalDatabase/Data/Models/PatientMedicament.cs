namespace P01_HospitalDatabase.Data.Models
{
    public class PatientMedicament
    {
        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        public int MedicamentId { get; set; }

        public virtual Medicament Medicament { get; set; }

    }
}
