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

        //static Thread readThread = new Thread(Read);
        static SerialPort serialPort = new SerialPort("COM10", 115200, Parity.None, 8, StopBits.One);

        public I2CThermometer()
        {
            TurnOn();
        }



        static bool _continue = false;
        public float GetTemperature()
        {
            byte[] buffer = new byte[10];

            serialPort.ReadTimeout = 5000;
            serialPort.WriteTimeout = 5000;
            
            serialPort.Open(); 
            serialPort.Write("Test");
            //string tempValueString = serialPort.ReadExisting();
            //if(serialPort.BytesToRead != 0)serialPort.Read(buffer, 0, buffer.Length);

            string val = null;

            //if(serialPort.BytesToRead != 0)
            val = serialPort.ReadLine();
            serialPort.Close();

            byte[] bytes = Encoding.UTF8.GetBytes(val);
            float fvalue= bytes[1]*10 + bytes[2] + (float)bytes[3]/10 + (float)bytes[3] / 100;
            float tempValue = buffer[1] + buffer[2]/10;
            //if (float.TryParse(tempValueString, out float temperatureFloat) == true) temperatureFloat = 0; //error?


            return 36.6F;

        }

        //public static void Read()
        //{
        //    while (_continue)
        //    {
        //        try
        //        {
        //            string messageReceived = serialPort.ReadLine();
                    
        //        }
        //        catch (TimeoutException) { }
        //    }
        //}

        public bool TurnOn()
        {

            //SerialCommunication sc = new SerialCommunication();
            //sc.SerialPortInit();
            //sc.OpenSerialPort();
            //sc.ReceiveData();

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
