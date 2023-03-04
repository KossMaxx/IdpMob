using idp.App.Droid.Services;
using idp.App.Services.Contracts;
using Java.Lang;
using Java.Net;
using Java.Util;
using Xamarin.Forms;

[assembly: Dependency(typeof(AncillaryService))]
namespace idp.App.Droid.Services
{
    public class AncillaryService : IAncillaryService
    {
        public string GetDeviceId()
        {
            var serialNumber = "";

            var allIntefaces = Collections.List(NetworkInterface.NetworkInterfaces);

            foreach (var nif in allIntefaces)
            {
                if(!(nif is NetworkInterface currentNif)) { continue;}

                if (currentNif.Name != "wlan0") {continue;}

                byte[] macBytes = currentNif.GetHardwareAddress();
                if (macBytes == null)
                {
                    break;
                }

                var sb = new StringBuilder();
                foreach (byte b in macBytes)
                {
                    sb.Append(Integer.ToHexString(b & 0xFF) + ":");
                }

                if (sb.Length() > 0)
                {
                    sb.DeleteCharAt(sb.Length() - 1);
                }
                serialNumber = sb.ToString();
            }

            return serialNumber;
        }
    }
}
