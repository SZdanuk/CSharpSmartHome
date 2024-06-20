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
        StartByteSend = 0x2A,
        EndByteSend = 0x2B,
        EndByte2Send = 0x2C,
        StartByteReceive = 0x2D,
        EndByteReceive = 0x2E,
        EndByte2Receive = 0x2F

    }


    public class SerialCommunication
    {

        static SerialPort serialPort = new SerialPort("COM10", 115200, Parity.None, 8, StopBits.One);

        public SerialCommunication()
        {
            SerialPortInit();
        }


        public enum SerialPortError
        {
            NoError,
            PortNotOpen
        }

        private void SerialPortInit()
        {
            serialPort.ReadTimeout = 5000;
            serialPort.WriteTimeout = 5000;
        }



        public SerialPortError OpenSerialPort()
        {

            try
            {
                if(serialPort.IsOpen == false)serialPort.Open();
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

            string data = "";

            try
            {
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
            string dataReceived = frame.DecodeFrame(Encoding.ASCII.GetBytes(ReceiveData()));


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

            if (frame.Length < 4 || (byte)frame[0] != (byte)FrameComponents.StartByteReceive || (byte)frame[frame.Length - 1] != (byte)FrameComponents.EndByteReceive)
            {
                return "Invalid frame";
            }

            byte checksum = CalculateChecksum(frame, frame.Length - 3);
            if (checksum != frame[frame.Length - 2])
            {
                return "Checksum error";
            }

            byte[] dataBytes = new byte[frame.Length - 3];
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
