using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDMicroExercises.TelemetrySystem;

internal class MockTelemetryClient : ITelemetryClient
{
    public const string DiagnosticMessage = "AT#UD";

    private bool _onlineStatus;
    private string sentMessage;

    public bool OnlineStatus
    {
        get { return _onlineStatus; }
    }

    public void Connect(string telemetryServerConnectionString)
    {
        _onlineStatus = true; 
    }

    public void Disconnect()
    {
        _onlineStatus = false;
    }

    public string Receive()
    {
        string message = string.IsNullOrEmpty(sentMessage)? "Waltuh" : sentMessage;
        // clear message
        sentMessage = string.Empty;
        return message;
    }

    public void Send(string message)
    {
        if (string.IsNullOrEmpty(message))
        {
            throw new ArgumentNullException();
        }

        if (message == DiagnosticMessage)
        {
            // simulate a status report
            sentMessage =
                "LAST TX rate................ 100 MBPS\r\n"
              + "HIGHEST TX rate............. 100 MBPS\r\n"
              + "LAST RX rate................ 100 MBPS\r\n"
              + "HIGHEST RX rate............. 100 MBPS\r\n"
              + "BIT RATE.................... 100000000\r\n"
              + "WORD LEN.................... 16\r\n"
              + "WORD/FRAME.................. 511\r\n"
              + "BITS/FRAME.................. 8192\r\n"
              + "MODULATION TYPE............. PCM/FM\r\n"
              + "TX Digital Los.............. 0.75\r\n"
              + "RX Digital Los.............. 0.10\r\n"
              + "BEP Test.................... -5\r\n"
              + "Local Rtrn Count............ 00\r\n"
              + "Remote Rtrn Count........... 00";

            return;
        }
    }
}