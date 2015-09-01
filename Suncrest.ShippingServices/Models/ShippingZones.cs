using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Suncrest.ShippingServices.Models
{
    public class ZipZone
    {
        public string Zip { get; set; }
        public string Zone { get; set; }

        public ZipZone(string zip, string zone)
        {
            this.Zip = zip;
            this.Zone = zone;

        }
    }

    public static class ShippingZones
    {
        static ZipZone[] _zipZoneCollection;

        static ShippingZones()
        {
            _zipZoneCollection = new ZipZone[]
            {
                new ZipZone("55555","4"),
                new ZipZone("55556","3"),
                new ZipZone("55557","9")
            };
        }

        public static ZipZone GetOne(string zip)
        {
            ZipZone zipZone;
            try
            {
                zipZone = _zipZoneCollection.First((z) => z.Zip == zip);
            }
            catch (InvalidOperationException)
            {
                zipZone = null;
            }

            return zipZone;
        }

        public static ZipZone[] GetAll()
        {
            return _zipZoneCollection;
        }
    }
}