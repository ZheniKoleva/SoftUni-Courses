using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string classToInvestigate, params string[] searchedFields)
        {
            StringBuilder sb = new StringBuilder();

            var flags = BindingFlags.Static | BindingFlags.NonPublic 
                        | BindingFlags.Public | BindingFlags.Instance;

            Type classType = Type.GetType(classToInvestigate);
            FieldInfo[] classFields = classType.GetFields(flags)
                .Where(f => searchedFields.Contains(f.Name))
                .ToArray();                

            Object classCreate = Activator.CreateInstance(classType, new object[] {});

            sb.AppendLine($"Class under investigation: {classType.Name}");

            foreach (var field in classFields)
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classCreate)}");
            }

            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(className);
            
            var fieldsFlags = BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance;

            List<string> classFields = classType.GetFields(fieldsFlags)
                .Select(f => f.Name)
                .ToList();

            var privateMethodsFlags = BindingFlags.NonPublic | BindingFlags.Instance;

            List<string> privateMethods = classType.GetMethods(privateMethodsFlags)
               .Where(m => m.Name.StartsWith("get"))
               .Select(m => m.Name)
               .ToList();

            var publicMethodsFlags = BindingFlags.Public | BindingFlags.Instance;

            List<string> publicMethods = classType.GetMethods(publicMethodsFlags)
                .Where(m => m.Name.StartsWith("set"))
                .Select(m => m.Name)
                .ToList();

            classFields
               .ForEach(field => sb.AppendLine($"{field} must be private!"));

            privateMethods.ToList()
                .ForEach(method => sb.AppendLine($"{method} must be public!"));

            publicMethods.ToList()
                  .ForEach(method => sb.AppendLine($"{method} must be private!"));
            
            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(className);

            var privateMethodsFlags = BindingFlags.NonPublic | BindingFlags.Instance;

           List<string> privateMethods = classType.GetMethods(privateMethodsFlags)
                .Select(m => m.Name)
                .ToList();

            sb.AppendLine($"All Private Methods of Class: {classType.Name}")
              .AppendLine($"Base Class: {classType.BaseType.Name}");

            privateMethods
                .ForEach(method => sb.AppendLine($"{method}"));

            return sb.ToString().TrimEnd();
        }

        public string CollectGettersAndSetters(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(className);

            var flags = BindingFlags.Static | BindingFlags.NonPublic
                        | BindingFlags.Public | BindingFlags.Instance;

            MethodInfo[] classMethods = classType.GetMethods(flags);

            foreach (var method in classMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (var method in classMethods.Where(m => m.Name.StartsWith("set")))
            {
                var setType = method.GetParameters().FirstOrDefault().ParameterType;

                sb.AppendLine($"{method.Name} will set field of {setType}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
