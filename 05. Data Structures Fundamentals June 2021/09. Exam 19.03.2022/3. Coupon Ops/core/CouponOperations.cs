using NUnit.Framework.Internal.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CouponOps
{
    public class CouponOperations : ICouponOperations
    {
        private Dictionary<string, Dictionary<Website, HashSet<Coupon>>> websites;
        private Dictionary<string, Coupon> coupons;       

        public CouponOperations()
        {
            websites = new Dictionary<string, Dictionary<Website, HashSet<Coupon>>>();
            coupons = new Dictionary<string, Coupon>();
        }

        public void RegisterSite(Website w)
        {
            if (Exist(w))
            {
                throw new ArgumentException();
            }

            websites.Add(w.Domain, new Dictionary<Website, HashSet<Coupon>>());
            websites[w.Domain].Add(w, new HashSet<Coupon>());           
        }

        public void AddCoupon(Website w, Coupon c)
        {
            if (!Exist(w))
            {
                throw new ArgumentException();
            }

            websites[w.Domain][w].Add(c);
            coupons.Add(c.Code, c);
        }

        public Website RemoveWebsite(string domain)
        {
            if (!websites.ContainsKey(domain))
            {
                throw new ArgumentException();
            }

            var toRemove = websites[domain].Keys.First();
            var websiteCoupons = websites[domain][toRemove];
            websites.Remove(domain);

            foreach (var item in websiteCoupons)
            {
                coupons.Remove(item.Code);
            }

            return toRemove;
        }

        public Coupon RemoveCoupon(string code)
        {
            if (!coupons.ContainsKey(code))
            {
                throw new ArgumentException();
            }

            var toRemove = coupons[code];

            foreach (var item in websites)
            {
                var currWebsite = item.Value.Keys.First();
                item.Value[currWebsite].Remove(toRemove);
            }

            coupons.Remove(code);

            return toRemove;
        }

        public bool Exist(Website w)
        {
            return websites.ContainsKey(w.Domain);
        }

        public bool Exist(Coupon c)
        {
            return coupons.ContainsKey(c.Code);
        }

        public IEnumerable<Website> GetSites()
        {
            var result = new List<Website>();

            foreach (var item in websites)
            {
                result.Add(item.Value.Keys.First());
            }
            return result;
        }

        public IEnumerable<Coupon> GetCouponsForWebsite(Website w)
        {
            if (!Exist(w))
            {
                throw new ArgumentException();
            }

            return websites[w.Domain][w].ToList();
        }

        public void UseCoupon(Website w, Coupon c)
        {
            var website = Exist(w) ? websites[w.Domain] : null;
            var coupon = Exist(c) ? coupons[c.Code] : null;

            if (website == null || coupon == null)
            {
                throw new ArgumentException();
            }

            if (!website[w].Contains(c))
            {
                throw new ArgumentException();
            }

            RemoveCoupon(c.Code);
        }

        public IEnumerable<Coupon> GetCouponsOrderedByValidityDescAndDiscountPercentageDesc()
        {
            return coupons.Values
                .OrderByDescending(c => c.Validity)
                .ThenByDescending(c => c.DiscountPercentage)
                .ToList();
        }

        public IEnumerable<Website> GetWebsitesOrderedByUserCountAndCouponsCountDesc()
        {
            var sorted = websites.Values
                .ToDictionary(x => x.Keys.First(), x => x[x.Keys.First()].Count)
                .OrderBy(x => x.Key.UsersCount)
                .ThenByDescending(x => x.Value)
                .Select(x => x.Key);                
                

            return sorted;
        }
    }
}
