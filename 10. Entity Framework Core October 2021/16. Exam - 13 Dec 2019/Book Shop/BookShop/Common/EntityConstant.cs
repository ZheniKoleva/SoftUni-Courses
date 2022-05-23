namespace BookShop.Common
{
    public class EntityConstant
    {
        //Author
        public const int Author_FirstName_Min_Length = 3;

        public const int Author_FirstName_Max_Length = 30;

        public const int Author_LastName_Min_Length = 3;

        public const int Author_LastName_Max_Length = 30;

        public const int Author_Phone_Length = 12;

        public const string Author_Phone_RegexPattern = @"^\d{3}-\d{3}-\d{4}$";

        public const int Author_BooksCollection_Min_Length = 1;

        //Book
        public const int Book_Name_Min_Length = 3;

        public const int Book_Name_Max_Length = 30;

        public const int Book_Pages_Min_Value = 50;

        public const int Book_Pages_Max_Value = 5000;

        public const decimal Book_Price_Min_Value = 0.01m;

        //public const decimal Book_Pages_Max_Value = decimal.MaxValue;

        public const int Book_Genre_Min_Value = 1;

        public const int Book_Genre_Max_Value = 3;

    }
}
