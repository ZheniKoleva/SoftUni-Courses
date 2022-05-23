using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {      
        private readonly string commandPrefix = "Command";

        public string Read(string inputArgs)
        {            
            string[] commandTokens = inputArgs.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string commandName = (commandTokens[0] + commandPrefix).ToLower();
            string[] commandArgs = commandTokens[1..];

            Assembly assembly = Assembly.GetCallingAssembly();
           
            Type classType = assembly.GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == commandName);

            if (classType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            ICommand classInstance = (ICommand)Activator.CreateInstance(classType);

            return classInstance.Execute(commandArgs);   
        }
    }
}