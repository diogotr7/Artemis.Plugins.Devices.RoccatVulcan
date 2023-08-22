using Artemis.Core.DeviceProviders;
using Artemis.Core.Services;
using RGBDeviceProvider = RGB.NET.Devices.Vulcan.VulcanDeviceProvider;


namespace Artemis.Plugins.Devices.RoccatVulcan
{
    public class VulcanDeviceProvider : DeviceProvider
    {
        private readonly IRgbService _rgbService;

        public VulcanDeviceProvider(IRgbService rgbService)
        {
            _rgbService = rgbService;
            CreateMissingLedsSupported = false;
            RemoveExcessiveLedsSupported = true;

            CanDetectLogicalLayout = false;
            CanDetectPhysicalLayout = false;
        }
        
        public override RGBDeviceProvider RgbDeviceProvider => RGBDeviceProvider.Instance;

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