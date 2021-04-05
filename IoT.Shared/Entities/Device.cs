using System;

namespace IoT.Shared.Entities
{
    public class Device
    {
        public Guid Id { get; set; }

        public DeviceType Type { get; set; }

        public int Minimum { get; set; }

        public int Maximum { get; set; }

        public int Interval { get; set; }

        public int Input { get; set; }

        public string Output { get; set; }

        public DeviceStatus Status { get; set; }

        public Device()
        {
            Id = Guid.Empty;
        }
    }
}