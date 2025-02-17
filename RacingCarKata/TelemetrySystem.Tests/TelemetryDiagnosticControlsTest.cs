using System;
using Xunit;

namespace TDDMicroExercises.TelemetrySystem.Tests
{
    public class TelemetryDiagnosticControlsTest
    {
        private const string diagnosticClientMessage =
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

        [Fact]
        public void CheckTransmission_should_send_a_diagnostic_message_and_receive_a_status_message_response()
        {
            var TelemetryDiagnosticControls = new TelemetryDiagnosticControls();
            while (true)
            {
                try
                {
                    TelemetryDiagnosticControls.CheckTransmission();
                    Assert.Equal(diagnosticClientMessage, TelemetryDiagnosticControls.DiagnosticInfo);
                    return;
                }
                catch (Exception e)
                {
                    continue;
                }
            }
        }

        [Fact]
        public void CheckTransmission_should_send_a_diagnostic_message_and_receive_a_status_message_response_mock_client()
        {
            var TelemetryDiagnosticControls = new TelemetryDiagnosticControls(new MockTelemetryClient());
            TelemetryDiagnosticControls.CheckTransmission();
            Assert.Equal(diagnosticClientMessage, TelemetryDiagnosticControls.DiagnosticInfo);
        }
    }
}
