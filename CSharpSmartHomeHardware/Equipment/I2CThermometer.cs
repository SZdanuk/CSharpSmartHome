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
        
        public I2CThermometer()
        {
            TurnOn();
        }

        public float GetTemperature()
        {

            SerialCommunication sc = new SerialCommunication();
            sc.OpenSerialPort();
            sc.SendFrame("GetTemp:1");
            string dataReceived = sc.ReceiveFrame();
            sc.CloseSerialPort();

            SerialCommunicationFrame sf = new SerialCommunicationFrame();
            return sf.GetTemperatureFromReceivedFrame(dataReceived);

        }

        


        public bool TurnOn()
        {

            return false;   //no error

        }


        public bool TurnOff()
        {

            return false;   //no error

        }

        ~I2CThermometer()
        {
            TurnOff();
        }

    }
}
