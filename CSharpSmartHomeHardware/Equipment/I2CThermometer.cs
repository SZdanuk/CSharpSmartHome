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

        #region Enums

        enum ThermometerError
        {
        
            NoError,
            TemperatureReadError
        
        }


        #endregion

        #region Constructor
        public I2CThermometer()
        {

        }

        #endregion

        #region PublicMethods

        public float GetTemperature()
        {

            if(TurnOn() == ThermometerError.TemperatureReadError)
            {
                return float.NaN;
            }
            SendFrame("GetTemp:1");
            ReceiveFrame();
            TurnOff();

            SerialCommunicationFrame sf = new SerialCommunicationFrame();
            return sf.GetTemperatureFromReceivedFrame(receivedData);

        }

        #endregion

        #region PrivateMethods
        private ThermometerError TurnOn()
        {

            sc = new SerialCommunication();
            if(sc.OpenSerialPort() != SerialCommunication.SerialPortError.NoError)
            {
                return ThermometerError.TemperatureReadError;
            }

            return ThermometerError.NoError;

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
