using CSharpSmartHomeApplication.Equipment;

namespace CSharpSmartHomeInfrastructure.Equipment;

public class InternetThermometer : IThermometer
{
    public float GetTemperature()
    {
        //throw new NotImplementedException();

        float temperature = 36.6F;
        return temperature;
    }
}