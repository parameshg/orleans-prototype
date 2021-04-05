using IoT.Shared.Entities;
using IoT.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoT.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class DeviceController : ControllerBase
    {
        private static List<Device> Devices { get; set; } = new List<Device>();

        private ILogger<DeviceController> Logger { get; }

        private IClusterClient Cluster { get; }

        public DeviceController(ILogger<DeviceController> logger, IClusterClient cluster)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));

            Cluster = cluster ?? throw new ArgumentNullException(nameof(cluster));
        }

        [HttpPost("devices")]
        public bool Register([FromBody] Device device)
        {
            Logger.LogInformation($"RegisterDevice | {Request.Method} {Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}");

            var result = false;

            if (device != null)
            {
                if (device.Id == Guid.Empty)
                {
                    device.Id = Guid.NewGuid();
                }

                device.Output = string.Empty;

                device.Status = DeviceStatus.Idle;

                Devices.Add(device);

                result = true;
            }

            return result;
        }

        [HttpDelete("devices/{id}")]
        public bool Unregister(Guid id)
        {
            Logger.LogInformation($"UnregisterDevice | {Request.Method} {Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}");

            var result = false;

            if (id != Guid.Empty)
            {
                result = Devices.RemoveAll(i => i.Id == id) > 0;
            }

            return result;
        }

        [HttpGet("devices/{id}/start")]
        public bool Start(Guid id)
        {
            Logger.LogInformation($"StartDevice | {Request.Method} {Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}");

            var result = false;

            if (id != Guid.Empty)
            {
                if (Devices.Count(i => i.Id == id) == 1)
                {
                    var device = Devices.FirstOrDefault(i => i.Id == id);

                    if (device != null)
                    {
                        device.Status = DeviceStatus.Running;

                        result = true;
                    }
                }
            }

            return result;
        }

        [HttpGet("devices/{id}/stop")]
        public bool Stop(Guid id)
        {
            Logger.LogInformation($"StopDevice | {Request.Method} {Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}");

            var result = false;

            if (id != Guid.Empty)
            {
                if (Devices.Count(i => i.Id == id) == 1)
                {
                    var device = Devices.FirstOrDefault(i => i.Id == id);

                    if (device != null)
                    {
                        device.Status = DeviceStatus.Idle;

                        result = true;
                    }
                }
            }

            return result;
        }

        [HttpGet("devices/{id}")]
        public async Task<string> Execute(Guid id, [FromQuery] int value)
        {
            Logger.LogInformation($"Execute | {Request.Method} {Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}");

            var result = string.Empty;

            var device = Devices.FirstOrDefault(i => i.Id == id);

            if (device != null && device.Status == DeviceStatus.Running)
            {
                switch (device.Type)
                {
                    case DeviceType.Factorial:
                        result = $"{(await Cluster.GetGrain<IFactorialFinder>(device.Id).Execute(value))}";
                        break;

                    case DeviceType.Prime:
                        result = $"{(await Cluster.GetGrain<IPrimeTester>(device.Id).Execute(value))}";
                        break;

                    case DeviceType.Mean:
                        result = $"{(await Cluster.GetGrain<IStatistics>(device.Id).GetMean(value))}";
                        break;

                    case DeviceType.Variance:
                        result = $"{(await Cluster.GetGrain<IStatistics>(device.Id).GetVariance(value))}";
                        break;

                    case DeviceType.Deviation:
                        result = $"{(await Cluster.GetGrain<IStatistics>(device.Id).GetStandardDeviation(value))}";
                        break;

                    default:
                        result = "ERROR";
                        break;
                }
            }

            return result;
        }
    }
}