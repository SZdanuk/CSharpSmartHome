using CSharpSmartHomeApplication;
using CSharpSmartHomeApplication.Equipment;
using CSharpSmartHomeInfrastructure.Equipment;

namespace CSharpSmartHomeCore;

public sealed class ThermometerFactory : IThermometerFactory
{
    public IThermometer CreateThermometer(ThermometerType type) =>
        type switch
        {
            ThermometerType.I2C => new I2CThermometer(),
            ThermometerType.Internet => new InternetThermometer(),
            ThermometerType.Spi => new SpiThermometer(),
            _ => throw new InvalidDataException()
        };
}