using System;

using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private const int Model_Length_Min_Limit = 4;

        private readonly int _minHorsePower;

        private readonly int _maxHorsePower;

        private string model;

        private int horsePower;

        private double cubicCentimeters;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            Model = model;
            _minHorsePower = minHorsePower;
            _maxHorsePower = maxHorsePower;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;

        }

        public string Model
        {
            get => model;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < Model_Length_Min_Limit)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, Model_Length_Min_Limit));
                }
            
                model = value;            
            }
        }

        public int HorsePower
        { 
            get => horsePower;
            private set
            {
                if (_minHorsePower > value || _maxHorsePower < value)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                horsePower = value;
            }       
        }
       

        public double CubicCentimeters
        { 
            get => cubicCentimeters;
            private set => cubicCentimeters = value;
        }
       

        public double CalculateRacePoints(int laps)
            => CubicCentimeters / HorsePower * laps;        
    }
}
