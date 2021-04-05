using IoT.Server.Interfaces;
using Orleans;
using Orleans.Concurrency;
using System.Threading.Tasks;

namespace IoT.Server
{
    [StatelessWorker]
    public class FactorialFinder : Grain, IFactorialFinder
    {
        public Task<decimal> Execute(int value)
        {
            decimal result = 1;

            while (value != 1)
            {
                result = result * value;

                value = value - 1;
            }

            return Task.FromResult(result);
        }
    }
}