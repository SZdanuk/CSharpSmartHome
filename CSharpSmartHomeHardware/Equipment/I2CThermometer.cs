using CSharpSmartHomeApplication.Equipment;
using CSharpSmartHomeHardware.Communication;
using System;
using System.Data.SqlTypes;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSmartHomeHardware.Equipment
{
    public class I2CThermometer : IThermometer
    {
        #region Fields

        private SerialCommunication sc;
        private string receivedData;

        #endregion

        #region Constructor
        public I2CThermometer()
        {

        }

        #endregion

        #region PublicMethods

        public float GetTemperature()
        {

            TurnOn();
            SendFrame("GetTemp:1");
            ReceiveFrame();
            TurnOff();

            SerialCommunicationFrame sf = new SerialCommunicationFrame();
            return sf.GetTemperatureFromReceivedFrame(receivedData.);

        }

        #endregion

        #region PrivateMethods
        private void TurnOn()
        {

            sc = new SerialCommunication();
            sc.OpenSerialPort();

        }

        private void TurnOff()
        {

            sc.CloseSerialPort();

        }

        private void SendFrame(string frame)
        {

            sc.SendFrame(frame);

        }
        
        private void ReceiveFrame()
        {

            receivedData = sc.ReceiveFrame().data;

        }

        #endregion

    }
}
