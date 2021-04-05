using Orleans;
using System.Threading.Tasks;

namespace IoT.Server.Interfaces
{
    public interface IPrimeTester : IGrainWithGuidKey
    {
        Task<bool> Execute(int value);
    }
}