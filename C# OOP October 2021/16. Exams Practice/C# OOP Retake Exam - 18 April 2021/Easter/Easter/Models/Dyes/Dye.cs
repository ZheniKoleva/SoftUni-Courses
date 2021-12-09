using Easter.Models.Dyes.Contracts;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private const int Default_Power_Decrease = 10;

        private int power;

        public Dye(int power)
        {
            Power = power;
        }

        public int Power
        {
            get => power;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                power = value;
            }        
        }


        public bool IsFinished() => power == 0;
        

        public void Use()
            => Power -= Default_Power_Decrease;       
    }
}
