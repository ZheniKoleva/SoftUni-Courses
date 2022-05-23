using System;
using System.Collections.Generic;
using System.Text;

namespace _03.SpeedRacing
{
    //public class Car
    //{
    //    private string model;

    //    private double fuelAmount;

    //    private double fuelConsumotion;

    //    private double distance;

    //    public Car(string modelName, double fuelAmount, double fuelConsumption)
    //    {
    //        Model = modelName;
    //        FuelAmount = fuelAmount;
    //        FuelConsumption = fuelConsumption;            
    //    }        

    //    public string Model { get; set; }

    //    public double FuelAmount { get; set; }

    //    public double FuelConsumption { get; set; }

    //    public double Distance { get; set; } = 0;

    //    public void CanMove(double distance) 
    //    {
    //        double fuelNeeded = FuelConsumption * distance;

    //        if (FuelAmount >= fuelNeeded)
    //        {
    //            FuelAmount -= fuelNeeded;
    //            Distance += distance;
    //        }
    //        else
    //        {
    //            Console.WriteLine("Insufficient fuel for the drive");
    //        }        
    //    }

    //    public override string ToString()
    //    {
    //        return $"{Model} {FuelAmount:f2} {Distance}";
    //    }

    //}
}
