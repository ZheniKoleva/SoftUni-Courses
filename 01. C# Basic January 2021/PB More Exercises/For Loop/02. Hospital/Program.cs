using System;

namespace _02.Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysPeriod = int.Parse(Console.ReadLine());

            int threatedPatients = 0;
            int unthreatedPatients = 0;
            int doctors = 7;

            for (int i = 1; i <= daysPeriod; i++)
            {
                if (i % 3 == 0 && unthreatedPatients > threatedPatients)
                {
                    doctors += 1;
                }
                int patients = int.Parse(Console.ReadLine());

                if (patients > doctors)
                {
                    threatedPatients += doctors;
                    unthreatedPatients += (patients - doctors);
                }
                else
                {
                    threatedPatients += patients;

                }
            }
            Console.WriteLine($"Treated patients: {threatedPatients}.");
            Console.WriteLine($"Untreated patients: {unthreatedPatients}.");
        }
    }
}
