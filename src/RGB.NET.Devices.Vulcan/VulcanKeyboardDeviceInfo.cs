using RGB.NET.Core;
using Vulcan.NET;

namespace RGB.NET.Devices.Vulcan
{
    public class VulcanKeyboardDeviceInfo : IRGBDeviceInfo
    {
        public RGBDeviceType DeviceType => RGBDeviceType.Keyboard;

        public string Manufacturer => "Roccat";

        public string DeviceName { get; }

        public string Model { get; }

        public object LayoutMetadata { get; set; }

        public IVulcanKeyboard VulcanKeyboard { get; }

        public VulcanKeyboardDeviceInfo(IVulcanKeyboard keyboard)
        {
            VulcanKeyboard = keyboard;

            Model = keyboard.KeyboardType switch
            {
                KeyboardType.Fullsize => "Vulcan 100/120",
                KeyboardType.Tenkeyless => "Vulcan TKL",
                _ => throw new System.NotImplementedException()
            };
            DeviceName = DeviceHelper.CreateDeviceName(Manufacturer, Model);
        }
    }
}