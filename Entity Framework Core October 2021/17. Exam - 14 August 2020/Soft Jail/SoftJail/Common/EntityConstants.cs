namespace SoftJail.Common
{
    public class EntityConstants
    {
        //Prisoner
        public const int Prisoner_FullName_Min_Length = 3;

        public const int Prisoner_FullName_Max_Length = 20;

        public const int Prisoner_Age_Min = 18;

        public const int Prisoner_Age_Max = 65;

        public const string Prisoner_Bail_Min = "0.0";

        public const string Prisoner_Bail_Max = "79228162514264337593543950335";

        public const string Prisoner_Nickname_Regex_Pattern = @"The [A-Z][a-z]+";

        //Officer
        public const int Officer_FullName_Min_Length = 3;

        public const int Officer_FullName_Max_Length = 30;

        public const string Officer_Salary_Min = "0.0";

        public const string Officer_Salary_Max = "79228162514264337593543950335";

        public const int Officer_Position_Enum_Min = 0;

        public const int Officer_Position_Enum_Max = 3;

        public const int Officer_Weapon_Enum_Min = 0;

        public const int Officer_Weapon_Enum_Max = 4;

        //Cell
        public const int Cell_CellNumber_Min = 1;

        public const int Cell_CellNumber_Max = 1000;

        //Mail
        public const string Mail_Address_Regex_Pattern = @"[A-Za-z0-9\s]+ str.";

        //Department
        public const int Department_Name_Min_Length = 3;

        public const int Department_Name_Max_Length = 25;

    }
}
