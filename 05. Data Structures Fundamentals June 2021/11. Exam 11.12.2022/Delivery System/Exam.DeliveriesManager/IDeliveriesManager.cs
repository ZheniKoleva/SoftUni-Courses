using System.Collections.Generic;

namespace Exam.DeliveriesManager
{
    public interface IDeliveriesManager
    {
        void AddDeliverer(Deliverer deliverer);

        void AddPackage(Package package);

        bool Contains(Deliverer deliverer);

        bool Contains(Package package);

        IEnumerable<Deliverer> GetDeliverers();

        IEnumerable<Package> GetPackages();

        void AssignPackage(Deliverer deliverer, Package package);

        IEnumerable<Package> GetUnassignedPackages();

        IEnumerable<Package> GetPackagesOrderedByWeightThenByReceiver();

        IEnumerable<Deliverer> GetDeliverersOrderedByCountOfPackagesThenByName();
    }
}
