using Artemis.Core.DeviceProviders;
using Artemis.Core.Services;
using RGB.NET.Devices.Vulcan;

namespace Artemis.Plugins.Devices.RoccatVulcan
{
    public class VulcanDeviceProvider : DeviceProvider
    {
        private readonly IRgbService _rgbService;

        public VulcanDeviceProvider(IRgbService rgbService) : base(RGB.NET.Devices.Vulcan.VulcanDeviceProvider.Instance)
        {
            _rgbService = rgbService;
        }

        public override void Enable()
        {
            _rgbService.AddDeviceProvider(RgbDeviceProvider);
        }

        public override void Disable()
        {
            _rgbService.RemoveDeviceProvider(RgbDeviceProvider);
            RgbDeviceProvider.Dispose();
        }
    }
}