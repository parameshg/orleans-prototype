using IoT.Shared.Entities;
using Redux;
using System;

namespace IoT.Devices.Redux.Actions
{
    public class CreateDevice : IAction
    {
        public Guid Id { get; set; }

        public DeviceType Type { get; set; }

        public int Minimum { get; set; }

        public int Maximum { get; set; }

        public int Interval { get; set; }
    }
}