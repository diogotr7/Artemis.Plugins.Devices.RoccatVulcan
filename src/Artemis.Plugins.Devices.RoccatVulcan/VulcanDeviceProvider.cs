using Artemis.Core.DeviceProviders;
using Artemis.Core.Services;
using RGBDeviceProvider = RGB.NET.Devices.Vulcan.VulcanDeviceProvider;


namespace Artemis.Plugins.Devices.RoccatVulcan
{
    public class VulcanDeviceProvider : DeviceProvider
    {
        private readonly IDeviceService _deviceService;

        public VulcanDeviceProvider(IDeviceService deviceService)
        {
            _deviceService = deviceService;
            CreateMissingLedsSupported = false;
            RemoveExcessiveLedsSupported = true;

            CanDetectLogicalLayout = false;
            CanDetectPhysicalLayout = false;
        }
        
        public override RGBDeviceProvider RgbDeviceProvider => RGBDeviceProvider.Instance;

        public override void Enable()
        {
            _deviceService.AddDeviceProvider(this);
        }

        public override void Disable()
        {
            _deviceService.RemoveDeviceProvider(this);
            RgbDeviceProvider.Dispose();
        }
    }
}