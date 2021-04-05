using IoT.Shared.Entities;
using Redux;
using System.Threading.Tasks;

namespace IoT.Devices.Redux.Reducers
{
    public class CreateDevice : Reducer
    {
        public override async Task<State> Execute(State state, IAction action)
        {
            var result = new State { Input = state.Input, Output = state.Output, Status = state.Status };

            if (action is Actions.CreateDevice command)
            {
                if (await Api.CreateDevice(new Device
                {
                    Id = command.Id,
                    Type = command.Type,
                    Minimum = command.Minimum,
                    Maximum = command.Maximum,
                    Interval = command.Interval
                }))
                {
                    result.Input = -1;
                    result.Output = "NaN";
                    result.Status = DeviceStatus.Idle;
                }
            }

            return result;
        }
    }
}