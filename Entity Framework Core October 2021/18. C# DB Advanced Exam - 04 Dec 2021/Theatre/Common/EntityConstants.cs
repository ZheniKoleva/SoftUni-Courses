namespace Theatre.Common
{
    public class EntityConstants
    {
        //Theatre
        public const int Theatre_Name_Min_Lenght = 4;

        public const int Theatre_Name_Max_Lenght = 30;

        public const sbyte Theatre_NumberOfHalls_Min_Value = 1;

        public const sbyte Theatre_NumberOfHalls_Max_Value = 10;

        public const int Theatre_Director_Min_Lenght = 4;

        public const int Theatre_Director_Max_Lenght = 30;


        //Play
        public const int Play_Title_Min_Lenght = 4;

        public const int Play_Title_Max_Lenght = 50;

        public const int Play_Duration_Min_Hours_Lenght = 1;

        public const string Play_Rating_Min_Value = "0.00";

        public const string Play_Rating_Max_Value = "10.00";

        public const int Play_Description_Max_Lenght = 700;

        public const int Play_Screewriter_Min_Lenght = 4;

        public const int Play_Screewriter_Max_Lenght = 30;

        //Cast
        public const int Cast_FullName_Min_Lenght = 4;

        public const int Cast_FullName_Max_Lenght = 30;

        public const int Cast_PhoneNumber_Max_Lenght = 15;

        public const string Cast_PhoneNumber_Regex_Pattern = @"^\+44\-\d{2}\-\d{3}\-\d{4}$";

        //Ticket
        public const string Ticket_Price_Min_Value = "1.00";

        public const string Ticket_Price_Max_Value = "100.00";

        public const sbyte Ticket_RowNumber_Min_Value = 1;

        public const sbyte Ticket_RowNumber_Max_Value = 10;

    }
}
