using CSharpSmartHomeApplication.Equipment;

namespace CSharpSmartHomeHardware.Equipment
{
    public class SpiThermometer : IThermometer
    {

        public SpiThermometer()
        {
            TurnOn();
        }

        public float GetTemperature()
        {

            return 25.1F;

        }


        public bool TurnOn()
        {

            return false;   //no error

        }


        public bool TurnOff()
        {

            return false;   //no error

        }

        ~SpiThermometer()
        {
            TurnOff();
        }

    }
}
