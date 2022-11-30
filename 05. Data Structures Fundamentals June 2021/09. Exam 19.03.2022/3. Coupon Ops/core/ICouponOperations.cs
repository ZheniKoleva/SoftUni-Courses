﻿using System;
using System.Collections.Generic;

namespace CouponOps
{
    public interface ICouponOperations
    {
        void RegisterSite(Website w);

        void AddCoupon(Website w, Coupon c);

        Website RemoveWebsite(string domain);

        Coupon RemoveCoupon(string code);

        bool Exist(Website w);

        bool Exist(Coupon c);

        IEnumerable<Website> GetSites();

        IEnumerable<Coupon> GetCouponsForWebsite(Website w);

        void UseCoupon(Website w, Coupon c);

        IEnumerable<Coupon> GetCouponsOrderedByValidityDescAndDiscountPercentageDesc();

        IEnumerable<Website> GetWebsitesOrderedByUserCountAndCouponsCountDesc();
    }
}
