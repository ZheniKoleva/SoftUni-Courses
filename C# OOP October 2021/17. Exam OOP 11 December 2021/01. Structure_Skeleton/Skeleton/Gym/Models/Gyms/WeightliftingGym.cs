namespace Gym.Models.Gyms
{
    public class WeightliftingGym : Gym
    {
        private const int Default_Capacity = 20;
        public WeightliftingGym(string name) 
            : base(name, Default_Capacity)
        {
        }
    }
}
