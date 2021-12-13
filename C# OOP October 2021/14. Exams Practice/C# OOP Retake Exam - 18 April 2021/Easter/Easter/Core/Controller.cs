using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private readonly BunnyRepository bunnies;

        private readonly EggRepository eggs;

        private readonly IWorkshop workshop;

        private int colorEggsCount;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
            workshop = new Workshop();
        }      


        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = CreateBunny(bunnyType, bunnyName);

            bunnies.Add(bunny);

            return string.Format(OutputMessages.BunnyAdded, bunny.GetType().Name, bunny.Name);
        }
               

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = bunnies.FindByName(bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            bunny.AddDye(new Dye(power));

            return string.Format(OutputMessages.DyeAdded, power, bunny.Name);
        }


        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);

            eggs.Add(egg);

            return string.Format(OutputMessages.EggAdded, egg.Name);
        }


        public string ColorEgg(string eggName)
        {
            IEgg eggToColor = eggs.FindByName(eggName);

            if (!bunnies.Models.Any(x => x.Energy >= 50))
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            while (!eggToColor.IsDone())
            {
                IBunny bunnyToColor = bunnies.Models
                    .Where(x => x.Energy >= 50 && x.Dyes.Any(x => !x.IsFinished()))
                    .OrderByDescending(x => x.Energy)
                    .FirstOrDefault();

                if (bunnyToColor == null)
                {
                    break;
                }

                workshop.Color(eggToColor, bunnyToColor);

                if (bunnyToColor.Energy == 0)
                {
                    bunnies.Remove(bunnyToColor);
                }

                if (eggToColor.IsDone())
                {
                    colorEggsCount++;
                    break;
                }
            }

            return eggToColor.IsDone()
                ? string.Format(OutputMessages.EggIsDone, eggToColor.Name)
                : string.Format(OutputMessages.EggIsNotDone, eggToColor.Name);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine($"{colorEggsCount} eggs are done!")
                .AppendLine("Bunnies info:");

            foreach (var bunny in bunnies.Models)
            {
                report.AppendLine(bunny.ToString());
            }

            return report.ToString().TrimEnd();
        }

        private IBunny CreateBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = bunnyType switch
            {
                nameof(HappyBunny) => new HappyBunny(bunnyName),
                nameof(SleepyBunny) => new SleepyBunny(bunnyName),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType),
            };
            return bunny;
        }
    }
}
