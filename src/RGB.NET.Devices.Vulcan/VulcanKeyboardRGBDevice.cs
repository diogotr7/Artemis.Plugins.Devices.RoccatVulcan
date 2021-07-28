using RGB.NET.Core;
using Vulcan.NET;

namespace RGB.NET.Devices.Vulcan
{
    public class VulcanKeyboardRGBDevice : AbstractRGBDevice<VulcanKeyboardDeviceInfo>
    {
        internal VulcanKeyboardRGBDevice(VulcanKeyboardDeviceInfo deviceInfo, IUpdateQueue updateQueue)
            : base(deviceInfo, updateQueue)
        {
            InitializeLayout();
        }

        private void InitializeLayout()
        {
            int x = 0;
            foreach (Key key in DeviceInfo.VulcanKeyboard.Keys)
            {
                if (!VulcanLedMapping.Mapping.TryGetValue(key, out LedId ledId))
                {
                    continue;
                }

                AddLed(ledId, new Point(x, 0), new Size(19), key);
                x += 20;
            }
        }
    }
}