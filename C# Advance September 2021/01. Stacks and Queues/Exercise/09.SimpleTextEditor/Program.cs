using System;
using System.Collections.Generic;
using System.Text;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());           
            
            StringBuilder text = new StringBuilder();
            Stack<string> trackChanges = new Stack<string>();

            for (int i = 0; i < commandsCount; i++)
            {
                string commandData = Console.ReadLine();                   

                switch (commandData[0])
                {
                    case '1':
                        string textToAppend = commandData[2..];
                        trackChanges.Push(text.ToString());
                        text.Append(textToAppend);
                        break;

                    case '2':
                        int countToErase = int.Parse(commandData[2..]);
                        trackChanges.Push(text.ToString());
                        text.Remove(text.Length - countToErase, countToErase);
                        break;

                    case '3':
                        int indx = int.Parse(commandData[2..]) - 1;
                        Console.WriteLine(text[indx]);
                        break;

                    case '4':
                        text = new StringBuilder(trackChanges.Pop());
                        break;
                }
            }
        }
    }
}
