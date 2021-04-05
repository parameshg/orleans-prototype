using IoT.Shared.Entities;
using IoT.Devices.Properties;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoT.Devices.Api
{
    public class Endpoint
    {
        public Task<List<Device>> GetDevices()
        {
            var result = new List<Device>();

            var api = new RestClient(Settings.Default.Api);

            var response = api.Get<List<Device>>(new RestRequest("/devices", Method.GET));

            if (response.IsSuccessful)
            {
                result.AddRange(response.Data);
            }

            return Task.FromResult(result);
        }

        public Task<bool> CreateDevice(Device device)
        {
            var result = false;

            var api = new RestClient(Settings.Default.Api);

            var request = new RestRequest("/devices", Method.POST, DataFormat.Json);

            request.AddJsonBody(device);

            var response = api.Post<bool>(request);

            if (response.IsSuccessful)
            {
                result = response.Data;
            }

            return Task.FromResult(result);
        }

        public Task<bool> StartDevice(Guid deviceId)
        {
            var result = false;

            var api = new RestClient(Settings.Default.Api);

            var request = new RestRequest($"/devices/{deviceId}/start", Method.GET);

            var response = api.Get<bool>(request);

            if (response.IsSuccessful)
            {
                result = response.Data;
            }

            return Task.FromResult(result);
        }

        public Task<string> SendEvent(Guid deviceId, int eventId)
        {
            var result = string.Empty;

            var api = new RestClient(Settings.Default.Api);

            var request = new RestRequest($"/devices/{deviceId}?value={eventId}", Method.GET);

            var response = api.Get<string>(request);

            if (response.IsSuccessful)
            {
                result = response.Data;
            }

            return Task.FromResult(result);
        }

        public Task<bool> StopDevice(Guid deviceId)
        {
            var result = false;

            var api = new RestClient(Settings.Default.Api);

            var request = new RestRequest($"/devices/{deviceId}/stop", Method.GET);

            var response = api.Get<bool>(request);

            if (response.IsSuccessful)
            {
                result = response.Data;
            }

            return Task.FromResult(result);
        }

        public Task<bool> DeleteDevice(Guid deviceId)
        {
            var result = false;

            var api = new RestClient(Settings.Default.Api);

            var request = new RestRequest($"/devices/{deviceId}", Method.DELETE, DataFormat.Json);

            request.AddJsonBody(deviceId);

            var response = api.Delete<bool>(request);

            if (response.IsSuccessful)
            {
                result = response.Data;
            }

            return Task.FromResult(result);
        }
    }
}