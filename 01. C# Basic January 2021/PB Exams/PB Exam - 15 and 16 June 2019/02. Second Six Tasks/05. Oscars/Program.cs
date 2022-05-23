using System;

namespace _05.Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double points = double.Parse(Console.ReadLine());
            int evaluatorsCount = int.Parse(Console.ReadLine());
            
            bool flagGotNomination = false;

            for (int evaluators = 0; evaluators < evaluatorsCount; evaluators++)
            {
                string evaluatorName = Console.ReadLine();
                double evaluatorPoints = double.Parse(Console.ReadLine());

                points += evaluatorName.Length * (evaluatorPoints / 2);

                if (points > 1250.50)
                {
                    flagGotNomination = true;                                        
                    break;
                }
            }

            if (flagGotNomination)
            {
                Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {points:f1}!");
            }
            else
            {
                Console.WriteLine($"Sorry, {actorName} you need {(1250.5 - points):f1} more!");
            }
        }
    }
}
