namespace Gym.Models.Gyms
{
    public class BoxingGym : Gym
    {
        private const int Default_Capacity = 15; 

        public BoxingGym(string name) 
            : base(name, Default_Capacity)
        {
        }
    }
}
