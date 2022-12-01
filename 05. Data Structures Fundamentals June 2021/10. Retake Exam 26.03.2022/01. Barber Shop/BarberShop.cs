using System;
using System.Collections.Generic;
using System.Linq;

namespace BarberShop
{
    public class BarberShop : IBarberShop
    {
        private Dictionary<string, Barber> barbers;
        private Dictionary<string, Client> clients;
        private Dictionary<Barber, HashSet<Client>> barberClients;

        public BarberShop()
        {
            barbers = new Dictionary<string, Barber>();
            clients = new Dictionary<string, Client>();
            barberClients = new Dictionary<Barber, HashSet<Client>>();
        }

        public void AddBarber(Barber b)
        {
            if (Exist(b))
            {
                throw new ArgumentException();
            }

            barbers.Add(b.Name, b);
            barberClients.Add(b, new HashSet<Client>());
        }

        public void AddClient(Client c)
        {
            if (Exist(c))
            {
                throw new ArgumentException();
            }

            clients.Add(c.Name, c);
        }

        public bool Exist(Barber b)
        {
            return barbers.ContainsKey(b.Name);
        }

        public bool Exist(Client c)
        {
            return clients.ContainsKey(c.Name);
        }

        public IEnumerable<Barber> GetBarbers()
        {
            return barbers.Values;
        }

        public IEnumerable<Client> GetClients()
        {
            return clients.Values;
        }

        public void AssignClient(Barber b, Client c)
        {
            var barber = Exist(b) ? b : null;
            var client = Exist(c) ? clients[c.Name] : null;

            if (barber == null || client == null)
            {
                throw new ArgumentException();
            }

            client.Barber = barber;
            barberClients[b].Add(client);
        }

        public void DeleteAllClientsFrom(Barber b)
        {
            if (!Exist(b))
            {
                throw new ArgumentException();
            }

            var allClients = barberClients[b];
            barberClients[b].Clear();

            foreach (var client in allClients)
            {
                clients[client.Name].Barber = null;
            }
        }

        public IEnumerable<Client> GetClientsWithNoBarber()
        {
            return clients.Values.Where(x => x.Barber == null);
        }

        public IEnumerable<Barber> GetAllBarbersSortedWithClientsCountDesc()
        {
            return barberClients
                .OrderByDescending(x => x.Value.Count)
                .Select(x => x.Key);
        }

        public IEnumerable<Barber> GetAllBarbersSortedWithStarsDecsendingAndHaircutPriceAsc()
        {
            return barbers.Values
                .OrderByDescending(x => x.Stars)
                .ThenBy(x => x.HaircutPrice);
        }

        public IEnumerable<Client> GetClientsSortedByAgeDescAndBarbersStarsDesc()
        {
            return clients.Values
                .Where(x => x.Barber != null)
                .OrderByDescending(x => x.Age)
                .ThenByDescending(x => x.Barber.Stars);
        }
    }
}
