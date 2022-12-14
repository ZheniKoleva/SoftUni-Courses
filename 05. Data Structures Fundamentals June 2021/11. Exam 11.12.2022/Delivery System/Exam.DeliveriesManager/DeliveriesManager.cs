using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.DeliveriesManager
{
    public class DeliveriesManager : IDeliveriesManager
    {
        private Dictionary<string, Deliverer> deliverers;
        private Dictionary<string, Package> packages;

        public DeliveriesManager()
        {
            deliverers = new Dictionary<string, Deliverer>();
            packages = new Dictionary<string, Package>();
        }                

        public void AddDeliverer(Deliverer deliverer)
        {
            if (!Contains(deliverer))
            {
                deliverers.Add(deliverer.Id, deliverer);
            }
        }

        public void AddPackage(Package package)
        {
            if (!Contains(package))
            {
                packages.Add(package.Id, package);
            }
        }

        public void AssignPackage(Deliverer deliverer, Package package)
        {
            var deliver = Contains(deliverer) ? deliverers[deliverer.Id] : null;
            var packageToAssign = Contains(package) ? packages[package.Id] : null;

            if (deliver == null || packageToAssign == null)
            {
                throw new ArgumentException();
            }

            packageToAssign.Deliverer = deliver;
            deliver.packages.Add(package);
        }

        public bool Contains(Deliverer deliverer)
        {
            return deliverers.ContainsKey(deliverer.Id);
        }

        public bool Contains(Package package)
        {
            return packages.ContainsKey(package.Id);
        }

        public IEnumerable<Deliverer> GetDeliverers()
        {
            return deliverers.Values;
        }

        public IEnumerable<Deliverer> GetDeliverersOrderedByCountOfPackagesThenByName()
        {
            return deliverers.Values
                .OrderByDescending(x => x.packages.Count)
                .ThenBy(x => x.Name);
        }

        public IEnumerable<Package> GetPackages()
        {
            return packages.Values;
        }

        public IEnumerable<Package> GetPackagesOrderedByWeightThenByReceiver()
        {
            return packages.Values
                .OrderByDescending(x => x.Weight)
                .ThenBy(x => x.Receiver);
        }

        public IEnumerable<Package> GetUnassignedPackages()
        {
            return packages.Values.
                Where(x => x.Deliverer == null);
        }
    }
}
