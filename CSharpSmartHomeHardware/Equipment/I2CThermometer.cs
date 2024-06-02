using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpSmartHomeApplication.AutomationSystemComponents;

namespace CSharpSmartHomeHardware
{
    public class I2CThermometer : IThermometer
    {

        public I2CThermometer()
        {
            TurnOn();
        }

        public float GetTemperature()
        {

            return 36.6F;

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
