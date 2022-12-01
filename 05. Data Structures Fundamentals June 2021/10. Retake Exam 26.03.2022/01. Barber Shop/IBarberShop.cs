using System;
using System.Collections.Generic;

namespace BarberShop
{
    public interface IBarberShop
    {
        void AddBarber(Barber b);

        void AddClient(Client c);

        bool Exist(Barber b);

        bool Exist(Client c);

        IEnumerable<Barber> GetBarbers();

        IEnumerable<Client> GetClients();

        void AssignClient(Barber b, Client c);

        void DeleteAllClientsFrom(Barber b);

        IEnumerable<Client> GetClientsWithNoBarber();

        IEnumerable<Barber> GetAllBarbersSortedWithClientsCountDesc();

        IEnumerable<Barber> GetAllBarbersSortedWithStarsDecsendingAndHaircutPriceAsc();

        IEnumerable<Client> GetClientsSortedByAgeDescAndBarbersStarsDesc();
    }
}
