using IoT.Devices.Api;
using IoT.Devices.Redux;
using IoT.Devices.Redux.Reducers;
using StructureMap;
using System;
using System.Windows.Forms;

namespace IoT.Devices
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            var container = new Container(cfg =>
            {
                cfg.ForConcreteType<Home>();
                cfg.ForConcreteType<State>();
                cfg.ForConcreteType<Reducer>();
                cfg.ForConcreteType<Endpoint>();
            });

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.GetInstance<Home>());
        }
    }
}