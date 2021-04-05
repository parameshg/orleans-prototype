using IoT.Shared.Entities;
using Redux;
using System.Threading.Tasks;

namespace IoT.Devices.Redux.Reducers
{
    public class DeleteDevice : Reducer
    {
        public override async Task<State> Execute(State state, IAction action)
        {
            var result = new State { Input = state.Input, Output = state.Output, Status = state.Status };

            if (action is Actions.DeleteDevice command)
            {
                if (await Api.DeleteDevice(command.DeviceId))
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