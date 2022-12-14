namespace Exam.DeliveriesManager
{
    public class Flight
    {
        public Flight(string id, string number, string origin, string destination, bool isCompleted)
        {
            Id = id;
            Number = number;
            Origin = origin;
            Destination = destination;
            IsCompleted = isCompleted;
        }

        public string Id { get; set; }

        public string Number { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public bool IsCompleted { get; set; }
    }
}
