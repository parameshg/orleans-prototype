using Redux;
using System;

namespace IoT.Devices.Redux.Actions
{
    public class SendEvent : IAction
    {
        public Guid DeviceId { get; set; }

        public int Value { get; set; }
    }
}