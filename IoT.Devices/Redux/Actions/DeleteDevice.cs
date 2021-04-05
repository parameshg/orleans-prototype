using Redux;
using System;

namespace IoT.Devices.Redux.Actions
{
    public class DeleteDevice : IAction
    {
        public Guid DeviceId { get; set; }
    }
}