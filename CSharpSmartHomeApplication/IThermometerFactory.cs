using CSharpSmartHomeApplication.Equipment;

namespace CSharpSmartHomeApplication;

public interface IThermometerFactory
{
    IThermometer CreateThermometer(ThermometerType type);
}