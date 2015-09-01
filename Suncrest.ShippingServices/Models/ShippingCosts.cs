using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Suncrest.ShippingServices.Models
{
    public class ShippingCost
    {
        public string Zone { get; set; }
        public decimal MinWeight { get; set; }
        public decimal MaxWeight { get; set; }
        public decimal Cost {get; set; }

        public ShippingCost(string zone, decimal minWeight, decimal maxWeight, decimal cost)
        {
            this.Zone = zone;
            this.MinWeight = minWeight;
            this.MaxWeight = maxWeight;
            this.Cost = cost;
        }
    }
    public class ShippingCosts
    {
        static ShippingCost[] _costCollection;

        static ShippingCosts()
        {
            _costCollection = new ShippingCost[]
            {
                new ShippingCost("4", 0.00m, 1.00m, 1.25m),
                new ShippingCost("4", 1.00m, 1.50m, 2.00m),
                new ShippingCost("4", 1.50m, 2.00m, 3.25m),
                new ShippingCost("3", 0m, 1m, 1.75m),
                new ShippingCost("3", 1.00m, 1.50m, 2.25m)
            };
        }

        public static ShippingCost GetOne(string zone, decimal weight)
        {
            ShippingCost rate;
            try
            {
                rate = _costCollection.First(r => ((r.Zone == zone) && (weight > r.MinWeight) && (weight <= r.MaxWeight)));
            }
            catch (InvalidOperationException)
            {
                rate = null;
            }
            
            return rate;
        }

        public static ShippingCost[] GetAll()
        {
            return _costCollection;
        }
    }
}