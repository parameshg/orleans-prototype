using IoT.Devices.Api;
using Redux;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace IoT.Devices.Redux.Reducers
{
    public interface IReducer
    {
        Task<State> Execute(State state, IAction action);
    }

    public class Reducer : IReducer
    {
        protected Endpoint Api { get; }

        public Reducer()
        {
            Api = new Endpoint();
        }

        public State Reduce(State state, IAction action)
        {
            return Execute(state, action).GetAwaiter().GetResult();
        }

        public virtual async Task<State> Execute(State state, IAction action)
        {
            var result = new State { Input = state.Input, Output = state.Output };

            var type = Assembly.GetExecutingAssembly().GetType(action.GetType().FullName.Replace("Action", "Reducer"));

            if (type != null)
            {
                if (Activator.CreateInstance(type) is IReducer reducer)
                {
                    result = await reducer.Execute(state, action);
                }
            }

            return result;
        }
    }
}