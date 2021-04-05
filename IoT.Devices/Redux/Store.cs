using IoT.Devices.Redux.Reducers;
using Redux;

namespace IoT.Devices.Redux
{
    public class Store : Store<State>
    {
        public Store(Reducer reducer, State state)
            : base(reducer.Reduce, state)
        {
        }
    }
}