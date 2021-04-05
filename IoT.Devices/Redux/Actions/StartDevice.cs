using Redux;
using System;

namespace IoT.Devices.Redux.Actions
{
    public class StartDevice : IAction
    {
        public Guid DeviceId { get; set; }
    }
}
