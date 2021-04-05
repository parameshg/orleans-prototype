using IoT.Server.Interfaces;
using Orleans;
using Orleans.Concurrency;
using System.Threading.Tasks;

namespace IoT.Server
{
    [StatelessWorker]
    public class PrimeTester : Grain, IPrimeTester
    {
        public Task<bool> Execute(int value)
        {
            var result = false;

            int count = 0;

            for (int i = 1; i <= value; i++)
            {
                if (value % i == 0)
                {
                    count++;
                }
            }

            if (count == 2)
            {
                result = true;
            }

            return Task.FromResult(result);
        }
    }
}