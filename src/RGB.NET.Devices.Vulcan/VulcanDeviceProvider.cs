using RGB.NET.Core;
using System;
using System.Collections.Generic;
using Vulcan.NET;

namespace RGB.NET.Devices.Vulcan
{
    public class VulcanDeviceProvider : AbstractRGBDeviceProvider
    {
        private static VulcanDeviceProvider _instance;
        public static VulcanDeviceProvider Instance => _instance ?? new VulcanDeviceProvider();

        public VulcanDeviceProvider()
        {
            if (_instance != null)
            {
                throw new InvalidOperationException($"There can be only one instance of type {nameof(VulcanDeviceProvider)}");
            }

            _instance = this;
        }

        #region Overrides of AbstractRGBDeviceProvider

        protected override void InitializeSDK()
        {
            // nothing
        }

        /// <inheritdoc />
        protected override IEnumerable<IRGBDevice> LoadDevices()
        {
            foreach (IVulcanKeyboard keyboard in VulcanFinder.FindKeyboards())
            {
                yield return new VulcanKeyboardRGBDevice(
                    new VulcanKeyboardDeviceInfo(keyboard),
                    new VulcanUpdateQueue(GetUpdateTrigger(),
                    keyboard)
                );
            }
        }

        #endregion
    }
}