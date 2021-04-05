using Redux;
using System.Linq;
using System.Threading.Tasks;

namespace IoT.Devices.Redux.Reducers
{
    public class SendEvent : Reducer
    {
        public override async Task<State> Execute(State state, IAction action)
        {
            var result = new State { Input = state.Input, Output = state.Output, Status = state.Status };

            if (action is Actions.SendEvent command)
            {
                result.Input = command.Value;

                result.Output = await Api.SendEvent(command.DeviceId, command.Value);
            }

            return result;
        }
    }
}