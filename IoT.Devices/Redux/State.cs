using IoT.Shared.Entities;

namespace IoT.Devices.Redux
{
    public class State
    {
        public int Input { get; set; } = -1;

        public string Output { get; set; } = "NaN";

        public DeviceStatus Status { get; set; } = DeviceStatus.Idle;
    }
}