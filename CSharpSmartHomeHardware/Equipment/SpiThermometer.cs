using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpSmartHomeApplication.AutomationSystemComponents;

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
