using System;
namespace BarberShop
{
    public class Barber
    {
        public Barber(string name, int haircutPrice, int stars)
        {
            this.Name = name;
            this.HaircutPrice = haircutPrice;
            this.Stars = stars;
        }

        public string Name { get; set; }
        public int HaircutPrice { get; set; }
        public int Stars { get; set; }
    }
}
