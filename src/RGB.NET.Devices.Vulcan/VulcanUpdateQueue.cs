using RGB.NET.Core;
using System;
using Vulcan.NET;

namespace RGB.NET.Devices.Vulcan
{
    public class VulcanUpdateQueue : UpdateQueue
    {
        private readonly IVulcanKeyboard _vulcanKeyboard;

        public VulcanUpdateQueue(IDeviceUpdateTrigger updateTrigger, IVulcanKeyboard vulcanKeyboard) : base(updateTrigger)
        {
            _vulcanKeyboard = vulcanKeyboard;
        }

        protected override bool Update(in ReadOnlySpan<(object key, Color color)> dataSet)
        {
            foreach ((object key, Color color) item in dataSet)
            {
                _vulcanKeyboard.SetKeyColor((Key)item.key, item.color.GetR(), item.color.GetG(), item.color.GetB());
            }

            return _vulcanKeyboard.Update();
        }
    }
}
