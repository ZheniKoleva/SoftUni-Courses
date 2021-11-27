namespace P03_SalesDatabase.Common
{
    public static class EntityConstants
    {
        //Product
        public const int PRODUCT_NAME_MAX_LENGTH = 50;

        public const int PRODUCT_DESCRIPTION_MAX_LENGTH = 250; //// 04. Product Migration

        public static readonly string PRODUCT_DESCRIPTION_DEFAULT_MESSAGE = "No description";

        //Customer
        public const int CUSTOMER_NAME_MAX_LENGTH = 100;

        public const int CUSTOMER_EMAIL_MAX_LENGTH = 80;

        //Store
        public const int STORE_NAME_MAX_LENGTH = 80;

    }
}
