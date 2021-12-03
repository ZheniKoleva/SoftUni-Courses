namespace VaporStore.Common
{
    public static class EntityConstants
    {
        //Game
        public const string Game_Price_Min_Value = "0.0";
        
        public const string Game_Price_Max_Value = "79228162514264337593543950335";

        public const int Game_GameTags_Min_Length = 1;


        //User
        public const int User_Username_Min_Length = 3;

        public const int User_Username_Max_Length = 20;

        public const string User_FullName_Regex_Pattern = @"^[A-Z][a-z]+ [A-Z][a-z]+$";

        public const int User_Age_Min_Value = 3;

        public const int User_Age_Max_Value = 103;

        public const int User_Cards_Min_Length = 1;

        //Card
        public const string Card_Number_Regex_Pattern = @"^\d{4} \d{4} \d{4} \d{4}$";

        public const string Card_Cvc_Regex_Pattern = @"^\d{3}$";

        public const int Card_Type_Min_Value = 0;

        public const int Card_Type_Max_Value = 1;

        //Purchase
        public const string Purchase_ProductKey_Regex_Pattern = @"^[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}$";

        public const int Purchase_Type_Min_Value = 0;

        public const int Purchase_Type_Max_Value = 1;

    }
}
