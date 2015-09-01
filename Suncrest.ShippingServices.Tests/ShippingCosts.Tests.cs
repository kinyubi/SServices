using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Suncrest.ShippingServices.Models;

namespace Suncrest.ShippingServices.Tests
{
    [TestClass]
    public class ShippingCostsTests
    {
        [TestMethod]
        public void GetAll_Returns_Array()
        {
            ShippingCost[] costs = ShippingCosts.GetAll();
            Assert.IsNotNull(costs);
            Assert.IsInstanceOfType(costs[0],typeof(ShippingCost));
        }

        [TestMethod]
        public void GetOne_BadZone()
        {
            ShippingCost rate = ShippingCosts.GetOne("5", 2.0m);
            Assert.IsNull(rate);
        }

        [TestMethod]
        public void GetOne_GoodZone_WeightOutOfRangeHighEdge()
        {
            ShippingCost rate = ShippingCosts.GetOne("4", 0m);
            Assert.IsNull(rate);
        }

        [TestMethod]
        public void GetOne_GoodZone_WeightInRangeLowEdge()
        {
            ShippingCost rate = ShippingCosts.GetOne("4", 0.01m);
            Assert.IsTrue(rate.Cost == 1.25m );
        }

        [TestMethod]
        public void GetOne_GoodZone_WeightOutOfRangeLowEdge()
        {
            ShippingCost rate = ShippingCosts.GetOne("4", 2.01m);
            Assert.IsNull(rate);
        }

        [TestMethod]
        public void GetOne_GoodZone_WeightInRangeHighEdge()
        {
            ShippingCost rate = ShippingCosts.GetOne("3", 1.5m);
            Assert.IsTrue(rate.Cost == 2.25m);
        }
    }
}
