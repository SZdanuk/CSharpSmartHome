using CSharpSmartHomeApplication.Equipment;

namespace CSharpSmartHomeHardware.Equipment
{
    public class InternetThermometer : IThermometer
    {

        public InternetThermometer()
        {
            TurnOn();
        }

        public float GetTemperature()
        {

            return -12.0F;

        }


        public bool TurnOn()
        {

            return false;   //no error

        }


        public bool TurnOff()
        {

            return false;   //no error

        }

        ~InternetThermometer()
        {
            TurnOff();
        }


    }
}
