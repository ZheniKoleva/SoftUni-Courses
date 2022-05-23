using System.Linq;

using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Workshops.Contracts;


namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (!egg.IsDone() && bunny.Energy > 0)
            {   
                IDye currentDye = bunny.Dyes.FirstOrDefault(x => !x.IsFinished());

                if (currentDye == null)
                {
                    break;
                }

                while (bunny.Energy > 0 && currentDye.Power > 0)
                {
                    bunny.Work();
                    currentDye.Use();
                    egg.GetColored();

                    if (egg.IsDone())
                    {
                        break;
                    }
                }
            }
        }
    }
}
