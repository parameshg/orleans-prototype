using Orleans;
using System.Threading.Tasks;

namespace IoT.Server.Interfaces
{
    public interface IFactorialFinder : IGrainWithGuidKey
    {
        Task<decimal> Execute(int value);
    }
}