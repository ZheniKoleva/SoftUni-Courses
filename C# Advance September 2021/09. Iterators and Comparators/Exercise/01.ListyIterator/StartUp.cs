namespace _01.ListyIterator
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] createCommand = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            ListyIterator<string> data = new ListyIterator<string>(createCommand[1..]);

            string commands;

            while ((commands = Console.ReadLine()) != "END")
            {
                switch (commands)
                {
                    case "Move":
                        Console.WriteLine(data.Move());
                        break;

                    case "HasNext":
                        Console.WriteLine(data.HasNext());
                        break;

                    case "Print":
                        try
                        {
                            data.Print();
                        }
                        catch (Exception ae)
                        {
                            Console.WriteLine(ae);
                        }                       
                        break;

                    case "PrintAll":
                        try
                        {
                            data.PrintAll();                            
                        }
                        catch (Exception ae)
                        {
                            Console.WriteLine(ae);
                        }
                        break;
                }                
            }
        }
    }
}
