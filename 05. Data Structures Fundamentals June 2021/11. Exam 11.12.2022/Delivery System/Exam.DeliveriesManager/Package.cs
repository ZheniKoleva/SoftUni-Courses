namespace Exam.DeliveriesManager
{
    public class Package
    {
        public Package(string id, string receiver, string address, string phone, double weight)
        {
            Id = id;
            Receiver = receiver;
            Address = address;
            Phone = phone;
            Weight = weight;
            Deliverer = null;
        }

        public string Id { get; set; }

        public string Receiver { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public double Weight { get; set; }

        public Deliverer Deliverer { get; set; }
    }
}
