using CSharpSmartHomeApplication.Equipment;
using CSharpSmartHomeHardware.Communication;
using System;
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

            return GetTemperatureFromReceivedData(dataReceived) ;

        }

        static private float GetTemperatureFromReceivedData(string dataReceived)//Gdzieś indziej ta metoda, ponad hardware
        {
            float tempFloat;

            try
            {
                if (dataReceived.Contains("Temp:"))
                {
                    dataReceived = dataReceived.Substring("Temp:".Length);
                }

                if (float.TryParse(dataReceived, out tempFloat))
                {
                    return tempFloat;
                }
                else
                {
                    throw new Exception("Can't convert temperature value to float");
                }
            }
            catch
            {
                tempFloat = 0F;
            }

            return 0F;
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
