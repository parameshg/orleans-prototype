using Orleans;
using System.Threading.Tasks;

namespace IoT.Server.Interfaces
{
    public interface IStatistics : IGrainWithGuidKey
    {
        Task<double> GetMean(int value);

        Task<double> GetVariance(int value);

        Task<double> GetStandardDeviation(int value);
    }
}