namespace _03.Stack
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack<string> data = new CustomStack<string>();

            string line;

            while ((line = Console.ReadLine()) != "END")
            {
                string[] arguments = line
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                switch (arguments[0])
                {
                    case "Push":
                        data.Push(arguments[1..]);
                        break;

                    case "Pop":
                        try
                        {
                            data.Pop();
                        }
                        catch (Exception ae)
                        {
                            Console.WriteLine(ae.Message);
                        }
                        break;
                }
            }

            foreach (var item in data)
            {
                Console.WriteLine(item);
            }

            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
        }
    }
}
