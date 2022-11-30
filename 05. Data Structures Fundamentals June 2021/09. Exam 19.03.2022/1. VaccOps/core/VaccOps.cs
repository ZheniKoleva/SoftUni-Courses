using System;
using System.Collections.Generic;
using System.Linq;

namespace VaccTests
{
    public class VaccOps
    {
        private Dictionary<string, Doctor> doctors;
        private Dictionary<string, Patient> patients;
        private Dictionary<Doctor, HashSet<Patient>> doctorsPatients;

        public VaccOps()
        {
            doctors = new Dictionary<string, Doctor>();
            patients = new Dictionary<string, Patient>();   
            doctorsPatients = new Dictionary<Doctor, HashSet<Patient>>();
        }

        public void AddDoctor(Doctor d)
        {
            if (Exist(d))
            {
                throw new ArgumentException();
            }

            doctors.Add(d.Name, d);
            doctorsPatients.Add(d, new HashSet<Patient>());
        }

        public void AddPatient(Doctor d, Patient p)
        {
            if (!Exist(d))
            {
                throw new ArgumentException();
            }

            if (!Exist(p))
            {
                patients.Add(p.Name, p);
            }

            if (doctorsPatients[d].Contains(p))
            {
                throw new ArgumentException();
            }

            doctorsPatients[d].Add(p);
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return doctors.Values.ToList();
        }

        public IEnumerable<Patient> GetPatients()
        {
            return patients.Values.ToList();
        }

        public bool Exist(Doctor d)
        {
            return doctors.ContainsKey(d.Name);
        }

        public bool Exist(Patient p)
        {
            return patients.ContainsKey(p.Name);
        }


        public Doctor RemoveDoctor(string name)
        {
            var doctorToRemove = doctors.ContainsKey(name) ? doctors[name] : null;

            if (doctorToRemove == null)
            {
                throw new ArgumentException();
            }
           
            doctors.Remove(name);
            var patientsList = doctorsPatients[doctorToRemove];
            doctorsPatients.Remove(doctorToRemove);

            foreach (var item in patientsList)
            {
                patients.Remove(item.Name);

                foreach (var currDoc in doctorsPatients)
                {
                    currDoc.Value.Remove(item);
                }
            }            

            return doctorToRemove;
        }

        public void ChangeDoctor(Doctor from, Doctor to, Patient p)
        {
            var fromDoctor = Exist(from) ? doctors[from.Name] : null;
            var toDoctor = Exist(to) ? doctors[to.Name] : null;
            var patient = Exist(p) ? patients[p.Name] : null;

            if (fromDoctor == null || toDoctor == null || patient == null)
            {
                throw new ArgumentException();
            }

            doctorsPatients[fromDoctor].Remove(patient);
            doctorsPatients[toDoctor].Add(patient);
        }

        public IEnumerable<Doctor> GetDoctorsByPopularity(int populariry)
        {
            return doctors.Values.Where(x => x.Popularity == populariry);
        }

        public IEnumerable<Patient> GetPatientsByTown(string town)
        {
            return patients.Values.Where(x => x.Town == town);
        }

        public IEnumerable<Patient> GetPatientsInAgeRange(int lo, int hi)
        {
            return patients.Values.Where(x => x.Age >= lo && x.Age <= hi);
        }

        public IEnumerable<Doctor> GetDoctorsSortedByPatientsCountDescAndNameAsc()
        {
            var doctorsNames = doctorsPatients
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key.Name)
                .Select(x => x.Key);                       

            return doctorsNames;    
        }


        public IEnumerable<Patient> GetPatientsSortedByDoctorsPopularityAscThenByHeightDescThenByAge()
        {            
            var sortedDoctors = doctorsPatients
                .OrderBy(x => x.Key.Popularity)
                .Select(x => x.Key); 

            var patientsByPopularity = new Dictionary<int, List<Patient>>();

            foreach (var doctor in sortedDoctors)
            {
                if (!patientsByPopularity.ContainsKey(doctor.Popularity))
                {
                    patientsByPopularity.Add(doctor.Popularity, new List<Patient>());
                }

                patientsByPopularity[doctor.Popularity].AddRange(doctorsPatients[doctor]);
            }

            var result = new List<Patient>();

            foreach (var items in patientsByPopularity.Values)
            {
                result.AddRange(items.OrderByDescending(p => p.Height)
                                     .ThenBy(p => p.Age));
            }

            return result;
        }
    }
}
