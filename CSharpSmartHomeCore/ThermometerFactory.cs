using CSharpSmartHomeApplication;
using CSharpSmartHomeApplication.Equipment;
using CSharpSmartHomeHardware;
using CSharpSmartHomeHardware.Equipment;

namespace CSharpSmartHomeCore
{
    public class ThermometerFactory : IThermometerFactory
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
