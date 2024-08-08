using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDMicroExercises.TelemetrySystem
{
    public interface ITelemetryClient
    {
        public void Connect(string telemetryServerConnectionString);
        public void Disconnect();
        public void Send(string message);
        public string Receive();

        public bool OnlineStatus
        {
            get;
        }
    }
}
