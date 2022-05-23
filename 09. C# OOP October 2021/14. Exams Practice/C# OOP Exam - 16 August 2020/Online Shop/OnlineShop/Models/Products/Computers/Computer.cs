using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private ICollection<IComponent> components;

        private ICollection<IPeripheral> peripherals;

        protected Computer(
            int id, 
            string manufacturer, 
            string model, 
            decimal price, 
            double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public override double OverallPerformance
            => components.Any() 
                ? base.OverallPerformance + components.Average(x => x.OverallPerformance)
                : base.OverallPerformance;

        public override decimal Price 
            => base.Price + components.Sum(x => x.Price) + peripherals.Sum(x => x.Price);

        public IReadOnlyCollection<IComponent> Components => (IReadOnlyCollection<IComponent>)components;

        public IReadOnlyCollection<IPeripheral> Peripherals => (IReadOnlyCollection<IPeripheral>)peripherals;

        public void AddComponent(IComponent component)
        {
            bool isExists = components
                .Any(x => x.GetType().Name == component.GetType().Name);

            if (isExists)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent,
                    component.GetType().Name, this.GetType().Name, this.Id));
            }

            components.Add(component);
        }
       

        public void AddPeripheral(IPeripheral peripheral)
        {
            bool isExists = peripherals
                .Any(x => x.GetType().Name == peripheral.GetType().Name);

            if (isExists)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral,
                    peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            IComponent toRemove = components
                .FirstOrDefault(x => x.GetType().Name.ToLower() == componentType.ToLower());

            if (!components.Any() || toRemove == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent,
                   componentType, this.GetType().Name, this.Id));
            }

            components.Remove(toRemove);

            return toRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral toRemove = peripherals
               .FirstOrDefault(x => x.GetType().Name.ToLower() == peripheralType.ToLower());

            if (!peripherals.Any() || toRemove == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral,
                   peripheralType, this.GetType().Name, this.Id));
            }

            peripherals.Remove(toRemove);

            return toRemove;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine(base.ToString());
            output.AppendLine($" {string.Format(SuccessMessages.ComputerComponentsToString, components.Count)}");

            foreach (var component in components)
            {
                output.AppendLine($"  {component}");
            }

            double avgOverall = peripherals.Any() 
                ? peripherals.Average(x => x.OverallPerformance) : 0;

            output.AppendLine($" {string.Format(SuccessMessages.ComputerPeripheralsToString, peripherals.Count, avgOverall.ToString("f2"))}");

            foreach (var peripheral in peripherals)
            {
                output.AppendLine($"  {peripheral}");
            }

            return output.ToString().TrimEnd();
        }
       
    }
}
