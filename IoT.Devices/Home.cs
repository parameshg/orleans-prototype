using EnsureThat;
using IoT.Shared.Entities;
using IoT.Devices.Redux;
using IoT.Devices.Redux.Actions;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IoT.Devices
{
    public partial class Home : Form
    {
        private Guid Id { get; set; } = Guid.NewGuid();

        private bool Running { get; set; } = false;

        private Store Store { get; set; }

        public Home(Store store)
        {
            InitializeComponent();

            Store = EnsureArg.IsNotNull(store);

            CheckForIllegalCrossThreadCalls = false;

            Text = $"{Text} [{Id}]";
        }

        private void OnLoad(object sender, EventArgs e)
        {
            foreach (var name in Enum.GetNames(typeof(DeviceType)))
            {
                cType.Items.Add(name);
            }

            Store.Subscribe(state =>
            {
                if (state.Status == DeviceStatus.Idle)
                {
                    lblMessage.Text = $"{state.Status}";
                }
                else
                {
                    lblMessage.Text = $"{state.Status} | f({state.Input}) = {state.Output}";
                }
            });
        }

        private void OnTimer(object sender, EventArgs e)
        {
            Store.Dispatch(new SendEvent { DeviceId = Id, Value = new Random(DateTime.Now.Millisecond).Next((int)nMinimum.Value, (int)nMaximum.Value) });
        }

        private async void OnStartStop(object sender, EventArgs e)
        {
            if (Running)
            {
                btnStartStop.Enabled = false;

                await StopDevice();
                tCounter.Interval = (int)nInterval.Value;
                tCounter.Enabled = false;
                tCounter.Stop();

                btnStartStop.Text = "START";
                btnStartStop.Enabled = true;
                Running = false;
            }
            else
            {
                btnStartStop.Enabled = false;

                await StartDevice();
                tCounter.Interval = (int)nInterval.Value;
                tCounter.Enabled = true;
                tCounter.Start();

                btnStartStop.Text = "STOP";
                btnStartStop.Enabled = true;
                Running = true;
            }
        }

        private async Task StartDevice()
        {
            await Task.Run(() =>
            {
                var request = new CreateDevice
                {
                    Id = Id,
                    Type = (DeviceType)Enum.Parse(typeof(DeviceType), cType.SelectedItem.ToString()),
                    Minimum = (int)nMinimum.Value,
                    Maximum = (int)nMaximum.Value,
                    Interval = (int)nInterval.Value,
                };

                Store.Dispatch(request);

                Store.Dispatch(new StartDevice { DeviceId = Id });
            });
        }

        private async Task StopDevice()
        {
            await Task.Run(() =>
            {
                Store.Dispatch(new StopDevice { DeviceId = Id });

                Store.Dispatch(new DeleteDevice { DeviceId = Id });
            });
        }
    }
}