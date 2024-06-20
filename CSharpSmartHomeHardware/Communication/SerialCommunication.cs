using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpSmartHomeHardware.Communication
{

    public enum FrameComponents : byte
    {
        StartByteSend = 0xAA,
        EndByteSend = 0xBB,
        EndByte2Send = 0xCC,
        StartByteReceive = 0xDD,
        EndByteReceive = 0xEE,
        EndByte2Receive = 0xFF

    }


    public class SerialCommunication
    {
        //SerialPort("COM10", 115200, Parity.None, 8, StopBits.One);
        //private SerialPort sp;
        //private SerialPort sp = new SerialPort("COM10", 115200, Parity.None, 8, StopBits.One);
        private SerialPort serialPort;
                

        //public SerialCommunication(SerialPort sp)
        //{
        //    try
        //    {
        //        SerialPort serialPort = sp;
        //    }
        //    catch
        //    {
        //        throw new Exception("serialPort in class construtor must be not-null");
        //    }

        //}

        public enum SerialPortError
        {
            NoError,
            PortNotOpen
        }

        public void SerialPortInit()
        {
            serialPort = new SerialPort("COM10", 115200, Parity.None, 8, StopBits.One);
            serialPort.ReadTimeout = 5000;
            serialPort.WriteTimeout = 5000;
        }



        public SerialPortError OpenSerialPort()
        {

            try
            {
                if(serialPort.IsOpen == false)  serialPort.Open();
                //if (serialPort.IsOpen == false) return SerialPortError.PortNotOpen;
            }
            catch
            {
                throw new Exception("Port opening error");
            }
            
            return SerialPortError.NoError;

        }

        public SerialPortError CloseSerialPort()
        {
            try
            {
                serialPort.Close();
            }
            catch
            {
                throw new Exception("Port closing error");
            }

            return SerialPortError.NoError;
            
        }

        SerialPortError SendData(byte[] dataToSend)
        {

            serialPort.Write(dataToSend, 0, dataToSend.Length);

            return SerialPortError.NoError;

        }

        string ReceiveData()
        {

            string data = null;

            try
            {
                //data = serialPort.ReadLine();
                data = serialPort.ReadLine();
            }
            catch(TimeoutException)
            {
                data = "timeout";
            }

            return data;
        }

        public bool SendFrame(string frameToSend)
        {

            SerialCommunicationFrame frame = new SerialCommunicationFrame();
            byte[] dataToSend = frame.BuildFrame(frameToSend);
            SendData(dataToSend);

            return false;
        }

        public string ReceiveFrame()
        {

            SerialCommunicationFrame frame = new SerialCommunicationFrame();
            string dataReceived = ReceiveData();

            return dataReceived;
        }


    }

    class SerialCommunicationFrame
    { 
        /*
         * Header
         * Data
         * CRC
         * Stop Bit
         */

        //example input strings: "Light1:ON, Light2:50, TempRegulator:25, GetTemp:1, GetDoorState:3, GetWindowState:10
        public byte[] BuildFrame(string command)
        {

            byte[] commandBytes = Encoding.ASCII.GetBytes(command);
            byte crc = CalculateChecksum(commandBytes);
            byte[] frame = new byte[commandBytes.Length + 4]; //Length + header, crc, 2 stop bits
            frame[0] = (byte)FrameComponents.StartByteSend;
            Array.Copy(commandBytes, 0, frame, 1, commandBytes.Length);
            frame[frame.Length - 3] = crc;                                  //3rd from last
            frame[frame.Length - 2] = (byte)FrameComponents.EndByteSend;    //2nd from last
            //frame[frame.Length - 1] = endByte2; //last

            return frame;
        }

        public string DecodeFrame(byte[] frame)
        {

            if (frame.Length < 4 || frame[0] != (byte)FrameComponents.StartByteReceive || frame[frame.Length - 1] != (byte)FrameComponents.EndByteReceive)
            {
                return "Invalid frame";
            }

            byte checksum = CalculateChecksum(frame, frame.Length - 3);
            if (checksum != frame[frame.Length - 2])
            {
                return "Checksum error";
            }

            byte[] dataBytes = new byte[frame.Length - 4];
            Array.Copy(frame, 1, dataBytes, 0, dataBytes.Length);

            string data = Encoding.ASCII.GetString(dataBytes);

            return data;

        }

        private byte CalculateChecksum(byte[] dataBytes)
        {
            byte checksum = 0;

            foreach (byte b in dataBytes)
            {
                checksum ^= b;
            }

            return checksum;
        }

        private byte CalculateChecksum(byte[] frame, int length)
        {
            byte checksum = 0;

            for (int i = 0; i < length; i++)
            {
                checksum ^= frame[i];
            }

            return checksum;
        }


    }
}
