﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpSmartHomeApplication;
using CSharpSmartHomeHardware;
using CSharpSmartHomeHardware.Equipment;
using CSharpSmartHomeApplication.AutomationSystemComponents;

namespace CSharpSmartHomeCore
{
    internal class ThermometerFactory : IThermometerFactory
    {

        public IThermometer CreateThermometer(ThermometerType thermometerType)
        {

            switch (thermometerType)
            {
                case ThermometerType.I2C:
                    return new I2CThermometer();
                case ThermometerType.SPI:
                    return new SpiThermometer();
                case ThermometerType.Internet:
                    return new InternetThermometer();
                default:
                    throw new NotImplementedException();
            }

        }

    }
}
