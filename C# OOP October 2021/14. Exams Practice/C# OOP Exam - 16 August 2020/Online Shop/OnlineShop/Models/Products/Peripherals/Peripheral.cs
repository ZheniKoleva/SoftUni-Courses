using OnlineShop.Common.Constants;

namespace OnlineShop.Models.Products.Peripherals
{
    public abstract class Peripheral : Product, IPeripheral
    {
        protected Peripheral(
            int id, 
            string manufacturer, 
            string model, 
            decimal price, 
            double overallPerformance,
            string connectionType) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            ConnectionType = connectionType;
        }

        public string ConnectionType { get; private set; }

        public override string ToString()
            => $"{base.ToString()}{string.Format(SuccessMessages.PeripheralToString, ConnectionType)}";
       
    }
}
