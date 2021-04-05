using IoT.Server.Interfaces;
using Orleans;
using Orleans.CodeGeneration;
using Orleans.Providers;
using Orleans.Runtime;
using Orleans.Serialization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoT.Server
{
    public class Stats
    {
        public int Minimum { get; set; } = -1;

        public int Maximum { get; set; } = -1;

        public List<int> Values { get; set; } = new List<int>();
    }

    public class Statistics : Grain, IStatistics
    {
        private Guid Id { get { return this.GetPrimaryKey(); } }

        private IPersistentState<Stats> Stats { get; }

        public Statistics([PersistentState("Stats", "SQLServer")] IPersistentState<Stats> stats)
        {

            Stats = stats ?? throw new ArgumentNullException(nameof(stats));
        }

        private async Task Normalize(int value = -1)
        {
            if (value >= 0 && !await GrainFactory.GetGrain<IPrimeTester>(Id).Execute(value))
            {
                if (Stats.State.Values.Count.Equals(0) && Stats.State.Minimum == -1) { Stats.State.Minimum = value; }

                if (value < Stats.State.Minimum) { Stats.State.Minimum = value; }

                if (value > Stats.State.Maximum) { Stats.State.Maximum = value; }

                Stats.State.Values.Add(value);

                await Stats.WriteStateAsync();
            }
        }

        public async Task<double> GetMean(int value = -1)
        {
            var result = 0d;

            await Normalize(value);

            Stats.State.Values.ForEach(i => result += i);

            result /= Stats.State.Values.Count;

            return Math.Round(result, 2);
        }

        public async Task<double> GetVariance(int value = -1)
        {
            var result = 0d;

            await Normalize(value);

            var mean = await GetMean();

            Stats.State.Values.ForEach(i => result += Math.Pow(i - mean, 2));

            result /= Stats.State.Values.Count;

            return result;
        }

        public async Task<double> GetStandardDeviation(int value = -1)
        {
            var result = 0d;

            await Normalize(value);

            result = Math.Sqrt(await GetVariance(value));

            return Math.Round(result, 2);
        }
    }
}