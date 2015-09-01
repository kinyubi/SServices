using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Suncrest.ShippingServices.Models;

namespace Suncrest.ShippingServices.Tests
{
    [TestClass]
    public class ShippingZonesTests
    {
        [TestMethod]
        public void GetAll_Returns_Array()
        {
            ZipZone[] zones = ShippingZones.GetAll();
            Assert.IsNotNull(zones);
            Assert.IsInstanceOfType(zones[0], typeof(ZipZone));
        }

        [TestMethod]
        public void GetOne_BadZip()
        {
            Assert.IsNull(ShippingZones.GetOne("55"));
            Assert.IsNull(ShippingZones.GetOne("55550"));
            Assert.IsNull(ShippingZones.GetOne("ABC"));
        }

        [TestMethod]
        public void GetOne_GoodZip_Edges()
        {
            ZipZone zipZone = ShippingZones.GetOne("55555");
            Assert.IsTrue(zipZone.Zip == "55555");
            Assert.IsTrue(zipZone.Zone == "4");

            zipZone = ShippingZones.GetOne("55557");
            Assert.IsTrue(zipZone.Zip == "55557");
            Assert.IsTrue(zipZone.Zone == "9");
        }
    }
}
