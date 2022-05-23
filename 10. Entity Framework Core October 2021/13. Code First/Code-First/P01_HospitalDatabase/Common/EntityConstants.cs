namespace P01_HospitalDatabase.Common
{
    public static class EntityConstants
    {
        //Patient
        public const int PATIENT_FIRSTNAME_MAX_LENGTH = 50;

        public const int PATIENT_LASTNAME_MAX_LENGTH = 50;

        public const int PATIENT_ADDRESS_MAX_LENGTH = 250;

        public const int PATIENT_EMAIL_MAX_LENGTH = 80;

        //Visitation
        public const int VISITATION_COMMENT_MAX_LENGTH = 250;

        //Diagnose
        public const int DIAGNOSE_NAME_MAX_LENGTH = 50;

        public const int DIAGNOSE_COMMENT_MAX_LENGTH = 250;

        //Medicament
        public const int MEDICAMENT_NAME_MAX_LENGTH = 50;


        //02. Hospital Database Modification
        //Doctor
        public const int DOCTOR_NAME_MAX_LENGTH = 100;

        public const int DOCTOR_SPECIALITY_MAX_LENGTH = 100;

    }
}
