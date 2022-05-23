using System;
using System.Linq;
using System.Collections.Generic;

using OnlineShop.Common.Enums;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly IDictionary<int, IComputer> computers;

        private readonly IDictionary<int, IComponent> components;

        private readonly IDictionary<int, IPeripheral> peripherals;

        public Controller()
        {
            computers = new Dictionary<int, IComputer>();
            components = new Dictionary<int, IComponent>();
            peripherals = new Dictionary<int, IPeripheral>();
        }

        public string AddComponent(
            int computerId, 
            int id, 
            string componentType, 
            string manufacturer, 
            string model, 
            decimal price, 
            double overallPerformance, 
            int generation)
        {
            IsComputerExists(computerId);

            IsComponentExists(id);

            IComputer computerToUpgrade = computers[computerId];

            IComponent componentToAdd = CreateComponent(id, componentType, manufacturer, model, price, overallPerformance, generation);

            computerToUpgrade.AddComponent(componentToAdd);

            components.Add(componentToAdd.Id, componentToAdd);

            return string.Format(SuccessMessages.AddedComponent,
                componentType, componentToAdd.Id, computerToUpgrade.Id);
        }

       

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {   
            if (computers.ContainsKey(id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            IComputer computer = CreateComputer(computerType, id, manufacturer, model, price);

            computers.Add(computer.Id, computer);

            return string.Format(SuccessMessages.AddedComputer, computer.Id);
        }
              

        public string AddPeripheral(
            int computerId, 
            int id, 
            string peripheralType, 
            string manufacturer, 
            string model, 
            decimal price, 
            double overallPerformance, 
            string connectionType)
        {
            IsComputerExists(computerId);

            IsPeripheralExists(id);

            IComputer computerToUpgrade = computers[computerId];           

            IPeripheral peripheral = CreatePeripheral(id, peripheralType, manufacturer, model, price, overallPerformance, connectionType);

            computerToUpgrade.AddPeripheral(peripheral);

            peripherals.Add(peripheral.Id, peripheral);

            return string.Format(SuccessMessages.AddedPeripheral,
                peripheralType, peripheral.Id, computerToUpgrade.Id);
        }       

        public string BuyBest(decimal budget)
        {
            if (!computers.Any() || computers.All(x => x.Value.Price > budget))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            IComputer bestComputer = computers
                .Where(x => x.Value.Price <= budget)
                .OrderByDescending(x => x.Value.OverallPerformance)
                .FirstOrDefault().Value;

            if (bestComputer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            computers.Remove(bestComputer.Id);

            return bestComputer.ToString();
        }

        public string BuyComputer(int id)
        {
            IsComputerExists(id);

            IComputer boughtComputer = computers[id];
            computers.Remove(id);

            return boughtComputer.ToString();
        }

        public string GetComputerData(int id)
        {
            IsComputerExists(id);

            return computers[id].ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IsComputerExists(computerId);

            IComputer computerToDowngrade = computers[computerId];

            IComponent toRemove = computerToDowngrade.RemoveComponent(componentType);

            components.Remove(toRemove.Id);

            return string.Format(SuccessMessages.RemovedComponent, componentType, toRemove.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IsComputerExists(computerId);

            IComputer computerToDowngrade = computers[computerId];

            IPeripheral toRemove = computerToDowngrade.RemovePeripheral(peripheralType);

            peripherals.Remove(toRemove.Id);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, toRemove.Id);
        }

        private void IsComputerExists(int id)
        {   
            if (!computers.ContainsKey(id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }

        private void IsComponentExists(int id)
        {
            if (components.ContainsKey(id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }
        }

        private void IsPeripheralExists(int id)
        {
            if (peripherals.ContainsKey(id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }
        }

        private static IComputer CreateComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer;

            if (computerType == ComputerType.DesktopComputer.ToString())
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else if (computerType == ComputerType.Laptop.ToString())
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            return computer;
        }
        
        private static IComponent CreateComponent(int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IComponent componentToAdd;

            if (componentType == ComponentType.CentralProcessingUnit.ToString())
            {
                componentToAdd = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.Motherboard.ToString())
            {
                componentToAdd = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.PowerSupply.ToString())
            {
                componentToAdd = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.RandomAccessMemory.ToString())
            {
                componentToAdd = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.SolidStateDrive.ToString())
            {
                componentToAdd = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.VideoCard.ToString())
            {
                componentToAdd = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            return componentToAdd;
        }

        private static IPeripheral CreatePeripheral(int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IPeripheral peripheral;

            if (peripheralType == PeripheralType.Headset.ToString())
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Keyboard.ToString())
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Monitor.ToString())
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Mouse.ToString())
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            return peripheral;
        }
    }

}
