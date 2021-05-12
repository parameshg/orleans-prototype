using IoT.Server.Host.Properties;
using IoT.Server.Interfaces;
using Microsoft.Extensions.Hosting;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using Orleans.Serialization;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IoT.Server.Host
{
    public partial class Home : Form
    {
        private Guid Id { get; set; } = Guid.NewGuid();

        private bool Running { get; set; } = false;

        private ISiloHost Host { get; set; }

        public Home()
        {
            InitializeComponent();

            Text = $"{Text} [{Id}]";
        }

        private async void OnStartStop(object sender, EventArgs e)
        {
            if (Running)
            {
                btnStartStop.Enabled = false;
                await StopServer();
                Running = false;
                btnStartStop.Text = "START";
                btnStartStop.Enabled = true;
            }
            else
            {
                btnStartStop.Enabled = false;
                await StartServer();
                Running = true;
                btnStartStop.Text = "STOP";
                btnStartStop.Enabled = true;
            }
        }

        private async Task StartServer()
        {
            if (Host == null)
            {
                var builder = new SiloHostBuilder()
                .UseAdoNetClustering(config => config.Configure(options =>
                {
                    options.ConnectionString = Settings.Default.Database;
                    options.Invariant = "System.Data.SqlClient";
                }))
                .Configure<ClusterOptions>(config =>
                {
                    config.ClusterId = "development";
                    config.ServiceId = "calculator";
                })
                .Configure<SerializationProviderOptions>(config =>
                {
                    config.SerializationProviders.Clear();
                    config.SerializationProviders.Add(typeof(BondSerializer));
                    config.FallbackSerializationProvider = typeof(BinaryFormatterSerializer);
                })
                .Configure<EndpointOptions>(config =>
                {
                    config.AdvertisedIPAddress = IPAddress.Loopback;
                    config.GatewayPort = (int)nPort.Value;
                    config.SiloPort = (int)nPort.Value + 10000;
                })
                .AddAdoNetGrainStorage("SQLServer", config => config.Configure(options =>
                {
                    options.ConnectionString = Settings.Default.Database;
                    options.Invariant = "System.Data.SqlClient";
                    options.UseJsonFormat = true;
                }))
                //.AddRedisGrainStorage("Redis", config => config.Configure(options =>
                //{
                //    options.ConnectionString = "127.0.0.1:6379";
                //    options.UseJson = true;
                //    options.DatabaseNumber = 1;
                //}))
                .ConfigureApplicationParts(parts =>
                {
                    parts.AddApplicationPart(typeof(IStatistics).Assembly).WithReferences();
                    parts.AddApplicationPart(typeof(Statistics).Assembly).WithReferences();
                });
                //.ConfigureLogging(logging => logging.AddConsole());

                Host = builder.Build();

                await Host.StartAsync();
            }
        }

        private async Task StopServer()
        {
            if (Host != null)
            {
                await Host.StopAsync();

                await Host.DisposeAsync();

                Host = null;
            }
        }
    }
}