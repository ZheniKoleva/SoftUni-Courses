using System;
using System.Reflection;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj) 
        { 
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                var propertyAttributtes = property.GetCustomAttributes(typeof(MyValidationAttribute), true);

                foreach (MyValidationAttribute attribute in propertyAttributtes)
                {
                    var propertyValue = property.GetValue(obj);

                    if (!attribute.IsValid(propertyValue))
                    {
                        return false;
                    }
                }                
            }

            return true;

        } 
    }
}
