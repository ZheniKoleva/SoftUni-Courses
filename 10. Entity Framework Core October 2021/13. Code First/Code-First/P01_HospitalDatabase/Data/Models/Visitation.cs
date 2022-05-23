using System;

namespace P01_HospitalDatabase.Data.Models
{
    public class Visitation
    {
        public int VisitationId { get; set; }

        public DateTime Date { get; set; }

        public string Comments { get; set; }

        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }


        // 02. Hospital Database Modification
        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

    }
}
