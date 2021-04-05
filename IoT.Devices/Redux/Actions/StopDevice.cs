using Redux;
using System;

namespace IoT.Devices.Redux.Actions
{
    public class StopDevice : IAction
    {
        public Guid DeviceId { get; set; }
    }
}