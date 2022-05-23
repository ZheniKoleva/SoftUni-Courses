namespace TeisterMask.Common
{
    public static class EntityConstants
    {
        //Employee
        public const int EMPLOYEE_USERNAME_MAX_LENGTH = 40;

        public const int EMPLOYEE_USERNAME_MIN_LENGTH = 3;

        public const string EMPLOYEE_USERNAME_REGEX = @"^[A-Za-z0-9]+$";

        public const string EMPLOYEE_PHONE_REGEX = @"^\d{3}\-\d{3}\-\d{4}$";


        //Project
        public const int PROJECT_NAME_MAX_LENGTH = 40;

        public const int PROJECT_NAME_MIN_LENGTH = 2;


        //Task
        public const int TASK_NAME_MAX_LENGTH = 40;

        public const int TASK_NAME_MIN_LENGTH = 2;

        public const int TASK_EXECITION_TYPE_MIN_VALUE = 0;

        public const int TASK_EXECITION_TYPE_MAX_VALUE = 3;

        public const int TASK_LABEL_TYPE_MIN_VALUE = 0;

        public const int TASK_LABEL_TYPE_MAX_VALUE = 4;


    }
}
